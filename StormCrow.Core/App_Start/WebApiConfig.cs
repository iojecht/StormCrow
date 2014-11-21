using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace StormCrow.Core
{
    public static class WebApiConfig
    {
        public static string ControllerOnly = "ApiControllerOnly";
        public static string ControllerAndId = "ApiControllerAndId";
        public static string ControllerAction = "ApiControllerAction";

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: ControllerOnly,
                routeTemplate: "api/{controller}"
            );

            config.Routes.MapHttpRoute(
                name: ControllerAndId,
                routeTemplate: "api/{controller}/{id}",
                defaults: null,
                constraints: new { id = @"^\d+$" }
            );

            config.Routes.MapHttpRoute(
                name: ControllerAction,
                routeTemplate: "api/{controller}/{action}"
            );

            // Make it Json
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //Then Validation
            config.Filters.Add(new ValidationActionFilter());
        }
    }
}
