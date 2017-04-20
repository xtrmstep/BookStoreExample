using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace BookStore.Api.Infrastructure
{
    internal class VersioningControllerSelector : DefaultHttpControllerSelector
    {
        private readonly HttpConfiguration _configuration;
        static Dictionary<string, HttpControllerDescriptor> result = null;
        static object _locker = new object();

        public VersioningControllerSelector(HttpConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public override IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            if (result == null)
            {
                lock (_locker)
                {
                    if (result == null)
                    {
                        result = new Dictionary<string, HttpControllerDescriptor>();
                        var controllers = _configuration.GetControllerTypes();

                        foreach (var controller in controllers)
                        {
                            var version = controller.GetControllerVersion();
                            var controllerName = controller.GetControllerName();
                            var key = ControllerHelpers.GetControllerKey(version, controllerName);
                            result.Add(key, new HttpControllerDescriptor(_configuration, controller.Name, controller));
                        }
                    }
                }
            }
            return result;
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var controllers = GetControllerMapping();
            var routeData = request.GetRouteData();

            var simpleController = routeData.Values["controller"];

            var controllerName = simpleController.ToString();
            var controllerVersion = request.RequestUri.Segments[2].Replace("/", string.Empty);

            HttpControllerDescriptor controllerDescriptor;

            var key = ControllerHelpers.GetControllerKey(controllerVersion, controllerName);
            if (controllers.TryGetValue(key, out controllerDescriptor))
            {
                return controllerDescriptor;
            }
            return null;
        }
    }
}