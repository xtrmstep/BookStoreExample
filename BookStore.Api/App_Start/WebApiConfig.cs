using System.Web.Http;
using System.Web.Http.Dispatcher;
using BookStore.Api.Infrastructure;
#pragma warning disable 1591

namespace BookStore.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/v1/{controller}/{id}", new {id = RouteParameter.Optional});
            config.Routes.MapHttpRoute("DefaultApiV2", "api/v2/{controller}/{id}", new {id = RouteParameter.Optional});

            config.Services.Replace(typeof (IHttpControllerSelector), new VersioningControllerSelector(config));
        }
    }
}