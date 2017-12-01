using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using FracViz.WebApi.AppStartup;

namespace FracViz.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            new Bootstrap().Start(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
