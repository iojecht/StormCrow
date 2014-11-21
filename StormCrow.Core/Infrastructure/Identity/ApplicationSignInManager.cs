using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using StormCrow.Core.Models;
using System.Security.Claims;
using System.Threading.Tasks;
namespace StormCrow.Core.Infrastructure.Identity
{
    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
            // Context
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }
    }
}