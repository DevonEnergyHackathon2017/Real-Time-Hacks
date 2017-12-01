using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using FracViz.WebApi.Controllers;
using FracViz.WebApi.Hubs;

namespace FracViz.WebApi.AppStartup
{
    public class Bootstrap
    {
        public void Start(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            Register(builder);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void Register(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly())
                .InstancePerRequest();

            builder.RegisterInstance(new PropagatorHub())
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}