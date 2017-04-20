using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;
using BookStore.Data.Models;
using BookStore.Data.Repositories;

namespace BookStore.Api.Controllers.V2
{
    /// <summary>
    ///     Information about books
    /// </summary>
    public class BooksController : V1.BooksController
    {
        /// <summary>
        ///     controller
        /// </summary>
        /// <param name="bookRepository"></param>
        public BooksController(IBookRepository bookRepository) : base(bookRepository)
        {
        }

        /// <summary>
        ///     Query books data with OData
        /// </summary>
        /// <returns></returns>
        [EnableQuery]
        [ResponseType(typeof (List<Book>))]
        public override IHttpActionResult Get()
        {
            return Ok(_bookRepository.GetQuery());
        }
    }
}