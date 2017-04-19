using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
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
            var controllers = _configuration.GetControllerTypes();

            foreach (var controller in controllers)
            {
                var version = controller.GetControllerVersion();
                var controllerName = controller.GetControllerName();
                var key = ControllerHelpers.GetControllerKey(version, controllerName);
                result.Add(key, new HttpControllerDescriptor(_configuration, controller.Name, controller));
            }
            return result;
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

                var key = ControllerHelpers.GetControllerKey(controllerVersion, controllerName);
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