using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using StormCrow.Core.Infrastructure.Identity;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using StructureMap.Web.Pipeline;
using StormCrow.Core.Infrastructure.Identity;
using StormCrow.Core.Models;

namespace StormCrow.Core.Infrastructure
{
    public class IdentityRegistry : Registry
    {
        public IdentityRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();

                For<ApplicationUserManager>().Use<ApplicationUserManager>(() => new ApplicationUserManager(new UserStore<ApplicationUser>()));

                For<ApplicationSignInManager>().Use<ApplicationSignInManager>(() => new ApplicationSignInManager(new ApplicationUserManager(new UserStore<ApplicationUser>()), HttpContext.Current.GetOwinContext().Authentication));

                For<ApplicationDbContext>().Use<ApplicationDbContext>(() => new ApplicationDbContext());

                For<IAuthenticationManager>().Use(c => HttpContext.Current.GetOwinContext().Authentication);

                For<IUserStore<ApplicationUser>>().Use<UserStore<ApplicationUser>>();
            });
        }
    }
}