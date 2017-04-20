using System.Web;
using System.Web.Http;
using BookStore.Api.App_Start;

#pragma warning disable 1591

namespace BookStore.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Configure(GlobalConfiguration.Configuration);
        }

        public static void Configure(HttpConfiguration config)
        {
            WebApiConfig.Register(config);
            BookStoreApiConfig.Register(config);
            config.EnsureInitialized();
        }
    }
}