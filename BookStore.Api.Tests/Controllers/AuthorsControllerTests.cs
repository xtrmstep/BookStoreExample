using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BookStore.Api.Models;
using BookStore.Data.Models;
using Xunit;

namespace BookStore.Api.Tests.Controllers
{
    [Collection("DbBoundTest")]
    public class AuthorsControllerTests: IClassFixture<HttpServerFixture>
    {
        private readonly HttpServerFixture _httpServer;
        private readonly TestDbFixture _testDb;

        public AuthorsControllerTests(HttpServerFixture httpServer, TestDbFixture testDb)
        {
            _httpServer = httpServer;
            _testDb = testDb;
        }

        [Fact(DisplayName = "api/v1/authors GET")]
        public void Should_return_the_list_of_available_hosts_v1()
        {
            using (var ctx = _testDb.CreateContext())
            {
                ctx.Authors.Add(new Author {Name = "0"});
                ctx.Authors.Add(new Author {Name = "1"});
                ctx.Authors.Add(new Author {Name = "2"});
                ctx.SaveChanges();

                using (var response = _httpServer.Get("api/v1/authors"))
                {
                    Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                    var content = response.Content as ObjectContent<List<AuthorReadModel>>;
                    Assert.NotNull(content);

                    var result = content.Value as List<AuthorReadModel>;
                    Assert.NotNull(result);

                    Assert.Equal(3, result.Count);
                }
            }
        }
    }
}
