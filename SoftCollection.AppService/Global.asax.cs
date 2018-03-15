using Autofac.Integration.WebApi;
using SoftCollection.Data.Model.ViewModal;
using SoftCollection.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace SoftCollection.AppService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static ResponseDetail responseDetail = new ResponseDetail();
        protected void Application_Start()
        {
            WebApiApplication.responseDetail = new ResponseDetail();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var config = GlobalConfiguration.Configuration;
            var builder = IoC.Configure();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
