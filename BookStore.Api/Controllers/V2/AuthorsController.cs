using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;
using AutoMapper;
using BookStore.Api.Controllers.V1;
using BookStore.Api.Models;
using BookStore.Data.Models;
using BookStore.Data.Repositories;

namespace BookStore.Api.Controllers.V2
{
    public class AuthorsController : V1.AuthorsController
    {
        public AuthorsController(IAuthorRepository authorRepository, IBookRepository bookRepository) : base(authorRepository, bookRepository)
        {
        }

        [EnableQuery]
        [ResponseType(typeof (List<Author>))]
        public override IHttpActionResult Get()
        {
            return Ok(AuthorRepository.GetQuery());
        }
    }
}