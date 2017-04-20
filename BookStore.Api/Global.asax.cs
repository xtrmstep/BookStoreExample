using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using BookStore.Api.App_Start;
using BookStore.Api.Infrastructure;
using BookStore.Data;

namespace BookStore.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Configure(GlobalConfiguration.Configuration);
        }

        public static void Configure(HttpConfiguration config = null)
        {
            WebApiConfig.Register(config);

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            builder.RegisterModule<DependencyConfiguration>();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());
            
            BookStoreApiConfig.Register();

            config.Services.Replace(typeof(IHttpControllerSelector), new VersioningControllerSelector(config));
            config.EnsureInitialized();

        }
    }
}
