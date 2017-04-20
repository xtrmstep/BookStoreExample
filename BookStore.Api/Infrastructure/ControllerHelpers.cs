using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace BookStore.Api.Infrastructure
{
    public static class ControllerHelpers
    {
        public static IEnumerable<Type> GetControllerTypes(this HttpConfiguration configuration)
        {
            var controllerTypeResolver = configuration.Services.GetHttpControllerTypeResolver();
            var assembliesResolver = configuration.Services.GetAssembliesResolver();
            return controllerTypeResolver.GetControllerTypes(assembliesResolver);
        }

        public static string GetControllerName(this Type controllerType)
        {
            return GetControllerName(controllerType.Name);
        }

        public static string GetControllerVersion(this Type controllerType)
        {
            var index = controllerType.Namespace.LastIndexOf("V");
            return index >= 0 ? controllerType.Namespace.Substring(index) : string.Empty;
        }

        public static string GetControllerKey(string controllerVersion, string controllerName)
        {
            return (controllerVersion + "/" + controllerName).ToLower();
        }

        public static int GetControllerVersion(this ApiDescription apiDesc)
        {
            var ctrlDescriptor = apiDesc.ActionDescriptor.ControllerDescriptor;
            var controllerNamespace = ctrlDescriptor.ControllerType.Namespace;
            var versionStartIndex = controllerNamespace.LastIndexOf("V");
            var controllerVersion = int.Parse(controllerNamespace.Substring(versionStartIndex + 1));
            return controllerVersion;
        }

        public static string GetCotrollerName(this ApiDescription apiDesc)
        {
            return GetControllerName(apiDesc.ActionDescriptor.ControllerDescriptor.ControllerName);
        }

        private static string GetControllerName(string controllerName)
        {
            return controllerName.Replace("Controller", string.Empty).ToLower();
        }

        public static string GetControllerVersion(this Uri uri)
        {
            for (int index = 0; index < uri.Segments.Length; index++)
            {
                var segment = uri.Segments[index];
                if (segment == "api/")
                {
                    return uri.Segments[index+1].Replace("/", string.Empty);
                }
            }
            return string.Empty;
        }

        public static string GetControllerName(this Uri uri)
        {
            for (int index = 0; index < uri.Segments.Length; index++)
            {
                var segment = uri.Segments[index];
                if (segment == "api/")
                {
                    return uri.Segments[index + 2].Replace("/", string.Empty);
                }
            }
            return string.Empty;
        }
    }
}