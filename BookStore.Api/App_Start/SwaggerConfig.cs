using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using BookStore.Api;
using BookStore.Api.Infrastructure;
using Swashbuckle.Application;
using Swashbuckle.OData;
using Swashbuckle.Swagger;
using WebActivatorEx;
#pragma warning disable 1591

[assembly: PreApplicationStartMethod(typeof (SwaggerConfig), "Register")]

namespace BookStore.Api
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.MultipleApiVersions(
                        ResolveVersionSupportByRouteConstraint,
                        vc =>
                        {
                            vc.Version("v2", "Book Store Inventory API V2");
                            vc.Version("v1", "Book Store Inventory API V1");
                        });

                    // You can use "BasicAuth", "ApiKey" or "OAuth2" options to describe security schemes for the API.
                    // See https://github.com/swagger-api/swagger-spec/blob/master/versions/2.0.md for more details.
                    // NOTE: These only define the schemes and need to be coupled with a corresponding "security" property
                    // at the document or operation level to indicate which schemes are required for an operation. To do this,
                    // you'll need to implement a custom IDocumentFilter and/or IOperationFilter to set these properties
                    // according to your specific authorization implementation
                    //
                    //c.BasicAuth("basic")
                    //    .Description("Basic HTTP Authentication");
                    //

                    // make controller names simple and low-case
                    c.GroupActionsBy(apiDesc => apiDesc.GetCotrollerName());

                    c.IncludeXmlComments(string.Format(@"{0}\bin\BookStore.Api.XML", AppDomain.CurrentDomain.BaseDirectory));

                    // adjustment required to compensate the change in controller selector logic
                    c.DocumentFilter<RemoveDupolicateVersionFromPathItems>();
                    c.CustomProvider(defaultProvider => new ODataSwaggerProvider(defaultProvider, c, GlobalConfiguration.Configuration));
                })
                .EnableSwaggerUi(c => { });
        }

        private static bool ResolveVersionSupportByRouteConstraint(ApiDescription apiDesc, string targetApiVersion)
        {
            // controller version
            var controllerVersion = apiDesc.GetControllerVersion();

            // requested version in Swagger
            var targetVersion = int.Parse(targetApiVersion.Substring(1));

            // version in URL
            var path = apiDesc.RelativePath.Split('/');
            var queryVersion = int.Parse(path[1].Substring(1));

            return targetVersion == controllerVersion
                   && targetVersion == queryVersion;
        }

        private class RemoveDupolicateVersionFromPathItems : IDocumentFilter
        {
            public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
            {
                var version = swaggerDoc.info.version;
                var result = new Dictionary<string, PathItem>();
                foreach (var pair in swaggerDoc.paths)
                {
                    // remove duplicate version from the key
                    // it was appeared because of the logic in VersioningControllerSelector
                    var key = pair.Key.Replace(string.Format("/api/{0}/{0}", version), "/api/" + version);
                    result.Add(key, pair.Value);
                }
                swaggerDoc.paths = result;
            }
        }
    }
}