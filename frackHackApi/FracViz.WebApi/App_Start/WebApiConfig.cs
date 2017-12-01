using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using FracViz.WebApi.AppStartup;

namespace FracViz.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
                = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional});

            config.MapHttpAttributeRoutes();
        }
    }
}
