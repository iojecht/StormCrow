using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Owin;

namespace Katana
{
    using AppFunc = Func<IDictionary<string,object>,Task>;

    class Program
    {
        public static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:8080"))
            {
                Console.WriteLine("WebServer Started!");
                Console.ReadKey();
                Console.WriteLine("WebServer Stopped!");
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.UseWelcomePage();
            //app.Run(ctx => ctx.Response.WriteAsync("Hello World!"));
        }
    }

    public class HelloWorldComponent
    {
        private AppFunc _next;
        public HelloWorldComponent(AppFunc next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            await _next(environment);
        }
    }
}
