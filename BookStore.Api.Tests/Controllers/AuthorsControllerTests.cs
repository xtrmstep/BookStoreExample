using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Results;
using BookStore.Api.Controllers.V1;
using BookStore.Api.Models;
using BookStore.Data.Models;
using BookStore.Data.Repositories;
using Moq;
using Xunit;

namespace BookStore.Api.Tests.Controllers
{
    [Collection("DbBoundTest")]
    public class AuthorsControllerTests : IClassFixture<HttpServerFixture>
    {
        private readonly HttpServerFixture _httpServer;
        private readonly TestDbFixture _testDb;

        public AuthorsControllerTests(HttpServerFixture httpServer, TestDbFixture testDb)
        {
            _httpServer = httpServer;
            _testDb = testDb;
        }

        [Trait("TestType", "Integration")]
        [Fact(DisplayName = "api/v1/authors GET")]
        public void Get_should_return_the_list_of_available_hosts_v1()
        {
            // db context with transaction
            using (var ctx = _testDb.CreateContext())
            {
                #region arrange

                ctx.Authors.Add(new Author {Name = "0"});
                ctx.Authors.Add(new Author {Name = "1"});
                ctx.Authors.Add(new Author {Name = "2"});
                ctx.SaveChanges();

                #endregion

                // act
                using (var response = _httpServer.Get("api/v1/authors"))
                {
                    #region assert

                    Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                    var content = response.Content as ObjectContent<List<AuthorReadModel>>;
                    Assert.NotNull(content);

                    var result = content.Value as List<AuthorReadModel>;
                    Assert.NotNull(result);

                    Assert.Equal(3, result.Count);

                    #endregion
                }
            }
            // transaction is not committed so that all data will be removed from DB
        }

        [Trait("TestType", "Integration")]
        [Fact(DisplayName = "api/v2/authors GET")]
        public void Get_should_return_the_list_of_available_hosts_v2()
        {
            // db context with transaction
            using (var ctx = _testDb.CreateContext())
            {
                #region arrange

                ctx.Authors.Add(new Author {Name = "0"});
                ctx.Authors.Add(new Author {Name = "1"});
                ctx.Authors.Add(new Author {Name = "2"});
                ctx.SaveChanges();

                #endregion

                // act
                using (var response = _httpServer.Get("api/v2/authors"))
                {
                    #region assert

                    Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                    var content = response.Content as ObjectContent<IQueryable<Author>>;
                    Assert.NotNull(content);

                    var result = content.Value as IQueryable<Author>;
                    Assert.NotNull(result);

                    Assert.Equal(3, result.ToList().Count);

                    #endregion
                }
            }
            // transaction is not committed so that all data will be removed from DB
        }

        [Trait("TestType", "Unit")]
        [Fact(DisplayName = "AuthorsController get()")]
        public void Should_return_the_list_of_available_hosts_v1()
        {
            #region arrange

            var list = new List<Author>(new[]
            {
                new Author {Name = "0"},
                new Author {Name = "1"},
                new Author {Name = "2"}
            });

            var bookRepository = Mock.Of<IBookRepository>();
            var authorRepository = new Mock<IAuthorRepository>();
            authorRepository.Setup(m => m.GetList()).Returns(list);
            var authorController = new AuthorsController(authorRepository.Object, bookRepository);

            #endregion

            // act
            var result = authorController.Get();

            #region assert

            var okResult = result as OkNegotiatedContentResult<List<AuthorReadModel>>;
            Assert.NotNull(okResult);

            Assert.Equal(3, okResult.Content.Count);

            #endregion
        }
    }
}