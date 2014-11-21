using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using StormCrow.Data;
using StormCrow.Data.Contract;
using StormCrow.Domain;
using StormCrow.Core.Controllers;

#if DEBUG
namespace StormCrow.Core.Scripts.Tests
{
    /// <summary>
    /// Test-only Web API controller to do things during testing
    /// that the real clients should NOT be able to do 
    /// (e.g., delete Sessions).
    /// DO NOT DEPLOY
    /// </summary>
    public class TestsController : ApiControllerBase
    {
        public TestsController(IUnitOfWork uow)
        {
            Uow = uow;
        }

        // GET: api/tests/testsessions
        [ActionName("TestSessions")]
        [EnableQuery]
        public IQueryable<Organization> GetTestSessions()
        {
            return Uow.Organizations.GetAll().Where(s => s.Name.StartsWith("TEST"));
        }

        // DELETE: api/tests/testsession/?id=42
        [HttpDelete, ActionName("TestSession")]
        public HttpResponseMessage DeleteTestSessionById(int id)
        {
            var org = Uow.Organizations.GetById(id);
            if (null != org)
            {
                if (!org.Name.StartsWith("TEST"))
                {
                    // not a TEST session; refuse to delete it
                    return new HttpResponseMessage(HttpStatusCode.Forbidden);
                }
                Uow.Organizations.Delete(org);
                Uow.Commit();
            }
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE: api/tests/testsessions
        [HttpDelete, ActionName("TestSessions")]
        public HttpResponseMessage DeleteAllTestSessions()
        {
            var testOrgs = GetTestSessions().ToList();
            var container = Uow.Organizations;
            testOrgs.ForEach(container.Delete);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
#endif