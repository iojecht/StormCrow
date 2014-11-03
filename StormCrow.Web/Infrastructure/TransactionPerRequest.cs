using System.Data.Entity;
using System.Web;
using StormCrow.Web.Data;
using StormCrow.Web.Infrastructure.Tasks;

namespace StormCrow.Web.Infrastructure
{
    public class TransactionPerRequest :
        IRunOnEachRequest, IRunOnError, IRunAfterEachRequest
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly HttpContextBase _httpContext;

        public TransactionPerRequest(ApplicationDbContext dbcontext,
            HttpContextBase httpContext)
        {
            _dbcontext = dbcontext;
            _httpContext = httpContext;
        }

        void IRunOnEachRequest.Execute()
        {
            _httpContext.Items["_Transaction"] =
                _dbcontext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

        }

        void IRunOnError.Execute()
        {
            _httpContext.Items["_Error"] = true;
        }

        void IRunAfterEachRequest.Execute()
        {
            var transaction = _httpContext.Items["_Transaction"] as DbContextTransaction;
            if (_httpContext.Items["_Error"] != null)
            {
                transaction.Rollback();
            }
            else
            {
                transaction.Commit();
            }
        }
    }
}