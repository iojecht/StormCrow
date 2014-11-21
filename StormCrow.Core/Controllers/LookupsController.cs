using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using StormCrow.Data;
using StormCrow.Domain;

namespace StormCrow.Core.Controllers
{
    public class LookupsController : ApiControllerBase
    {
        public LookupsController(IUnitOfWork uow)
        {
            Uow = uow;
        }

        [ActionName("Organization")]
        public IEnumerable<Organization> GetOrganizations()
        {
            return Uow.Organizations.GetAll().OrderBy(o => o.Name);
        }
    }
}
