using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;
using BookStore.Api.Controllers.V1;
using BookStore.Data.Models;
using BookStore.Data.Repositories;

namespace BookStore.Api.Controllers.V2
{
    public class BooksController : V1.BooksController
    {
        public BooksController(IBookRepository bookRepository) : base(bookRepository)
        {
        }

        [EnableQuery]
        [ResponseType(typeof(List<Book>))]
        public override IHttpActionResult Get()
        {
            return Ok(_bookRepository.GetQuery());
        }
    }
}