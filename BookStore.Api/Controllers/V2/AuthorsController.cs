using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using BookStore.Api.Controllers.V1;
using BookStore.Api.Models;
using BookStore.Data.Repositories;

namespace BookStore.Api.Controllers.V2
{
    public class AuthorsController : V1.AuthorsController
    {
        public AuthorsController(IAuthorRepository authorRepository) : base(authorRepository)
        {
        }

        [ResponseType(typeof (List<AuthorReadModel>))]
        public override IHttpActionResult Get()
        {
            return Ok(new List<AuthorReadModel>());
        }
    }
}