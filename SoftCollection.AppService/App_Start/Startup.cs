using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using SoftCollection.DI;
using System.Reflection;
using Autofac.Integration.WebApi;

[assembly: OwinStartup(typeof(SoftCollection.AppService.App_Start.Startup))]

namespace SoftCollection.AppService.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
            ConfigureIoC(app, config);
        }
        private static void ConfigureIoC(IAppBuilder app, HttpConfiguration config)
        {
            var builder = IoC.Configure();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            app.UseAutofacMiddleware(container);
            // app.UseAutofacWebApi(config);
            app.UseWebApi(config);
        }
    }
}
