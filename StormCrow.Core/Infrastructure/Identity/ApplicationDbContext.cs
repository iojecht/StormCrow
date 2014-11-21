using Microsoft.AspNet.Identity.EntityFramework;
using StormCrow.Core.Models;
namespace StormCrow.Core.Infrastructure.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("StormCrowIdentity", throwIfV1Schema: false)
        {
        }
    }
}