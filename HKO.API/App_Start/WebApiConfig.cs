using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using HKO.API.Filters;

namespace HKO.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //var cors = new EnableCorsAttribute("http://hko.poslovna.hr", "*", "*");
            var cors = new EnableCorsAttribute("*", "*", "get");
            config.EnableCors(cors);

            //An exception has occurred while using the formatter 'JsonMediaTypeFormatter' to generate sample for media type 'application/json'.Exception message: Self referencing loop detected with type
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            // Web API routes
            config.MapHttpAttributeRoutes();

            // config.Routes.MapHttpRoute(
            //     name: "GetAll",
            //     routeTemplate: "api/{controller}"
            // );

            // config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);


        }
    }
}
