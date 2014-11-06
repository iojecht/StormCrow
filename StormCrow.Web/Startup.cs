using StormCrow.Web;
using System.Web.Mvc;
using Microsoft.Owin;
using Owin;
using StormCrow.Web.DependencyResolution;
using StructureMap;

[assembly: OwinStartupAttribute(typeof(StormCrow.Web.Startup))]
namespace StormCrow.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
