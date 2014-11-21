using System.Web.Http;
using StormCrow.Data;

namespace StormCrow.Core.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
        protected IUnitOfWork Uow { get; set; }
    }
}