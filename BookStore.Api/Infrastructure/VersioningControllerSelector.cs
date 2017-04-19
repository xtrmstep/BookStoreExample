using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using System.Web.Http.Dispatcher;

namespace BookStore.Api.Infrastructure
{
    internal class VersioningControllerSelector : IHttpControllerSelector
    {
        private readonly HttpConfiguration _configuration;

        public VersioningControllerSelector(HttpConfiguration config)
        {
            _configuration = config;
        }

        public IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            var result = new Dictionary<string, HttpControllerDescriptor>();
            var controllers = GetControllerTypes();

            foreach (var controller in controllers)
            {
                var version = GetControllerVersion(controller);
                var controllerName = GetControllerName(controller);
                var key = GetControllerKey(version, controllerName);
                result.Add(key, new HttpControllerDescriptor(_configuration, controller.Name, controller));
            }
            return result;
        }

        private IEnumerable<Type> GetControllerTypes()
        {
            return (IEnumerable<Type>) _configuration.Services.GetHttpControllerTypeResolver().GetControllerTypes(_configuration.Services.GetAssembliesResolver());
        }

        private static string GetControllerName(Type controller)
        {
            return controller.Name.Replace("Controller", string.Empty).ToLower();
        }

        private static string GetControllerVersion(Type controller)
        {
            return controller.Namespace.Substring(controller.Namespace.LastIndexOf("V"));
        }

        private static string GetControllerKey(string controllerVersion, string controllerName)
        {
            return (controllerVersion + "/" + controllerName).ToLower();
        }

        public HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            try
            {
                var controllers = GetControllerMapping();
                var routeData = request.GetRouteData();

                var controllerName = routeData.Values["controller"].ToString();
                var controllerVersion = request.RequestUri.Segments[2].Replace("/", string.Empty);

                HttpControllerDescriptor controllerDescriptor;

                var key = GetControllerKey(controllerVersion, controllerName);
                if (controllers.TryGetValue(key, out controllerDescriptor))
                {
                    return controllerDescriptor;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}