using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using StormCrow.Data;

namespace StormCrow.Web.Controllers
{
    public class OrganizationController : ApiControllerBase
    {
        public OrganizationController(IUnitOfWork uow)
        {
            Uow = uow;
        }

        // GET: api/Organization
        public IEnumerable<string> Get()
        {
            return Uow.Organizations.GetAll().OrderBy(o => o.Name).Select(p => p.Name);
        }

        // GET: api/Organization/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Organization
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Organization/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Organization/5
        public void Delete(int id)
        {
        }
    }
}
