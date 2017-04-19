using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace BookStore.Api.Infrastructure
{
    public class VersioningControllerSelector : DefaultHttpControllerSelector
    {
        public VersioningControllerSelector(HttpConfiguration config) : base(config)
        {
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            try
            {
                var controllers = GetControllerMapping();
                var routeData = request.GetRouteData();

                var controllerName = routeData.Values["controller"].ToString();
                var version = request.RequestUri.Segments[2].Replace("/", string.Empty);
                HttpControllerDescriptor controllerDescriptor;

                if (controllers.TryGetValue(controllerName+ version, out controllerDescriptor))
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