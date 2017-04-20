using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Api.Infrastructure;
using Xunit;

namespace BookStore.Api.Tests.Infrastructure
{
    public class ControllerHelpersTests
    {
        [Theory(DisplayName = "GetControllerVersion should extract version from URI")]
        [InlineData("http://localhost/BookStore.Api/api/v2/authors", "v2")]
        [InlineData("http://localhost:53532/api/v2/authors?$filter=Name eq 'string'", "v2")]
        [InlineData("http://www.site.com/api/v2/authors", "v2")]
        public void GetControllerVersion_should_return_version_from_uri(string uri, string expected)
        {
            var actual = new Uri(uri).GetControllerVersion();
            Assert.Equal(expected, actual);
        }

        [Theory(DisplayName = "GetControllerName should extract name from URI")]
        [InlineData("http://localhost/BookStore.Api/api/v2/authors", "authors")]
        [InlineData("http://localhost:53532/api/v2/authors?$filter=Name eq 'string'", "authors")]
        [InlineData("http://www.site.com/api/v2/authors", "authors")]
        public void GetControllerName_should_return_name_from_uri(string uri, string expected)
        {
            var actual = new Uri(uri).GetControllerName();
            Assert.Equal(expected, actual);
        }
    }
}
