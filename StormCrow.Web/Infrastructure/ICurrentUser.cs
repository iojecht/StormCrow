using Microsoft.AspNet.Identity.EntityFramework;

namespace StormCrow.Web.Infrastructure
{
    public interface ICurrentUser
    {
        IdentityUser User { get; }
    }
}