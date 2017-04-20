using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;
using BookStore.Api.Models;
using BookStore.Data.Models;
using BookStore.Data.Repositories;

namespace BookStore.Api.Controllers.V2
{
    /// <summary>
    ///     Information about authors
    /// </summary>
    public class AuthorsController : V1.AuthorsController
    {
        /// <summary>
        ///     controller
        /// </summary>
        /// <param name="authorRepository"></param>
        /// <param name="bookRepository"></param>
        public AuthorsController(IAuthorRepository authorRepository, IBookRepository bookRepository) : base(authorRepository, bookRepository)
        {
        }

        /// <summary>
        ///     Query authors data with OData
        /// </summary>
        /// <returns></returns>
        [EnableQuery]
        [ResponseType(typeof (List<Author>))]
        public override IHttpActionResult Get()
        {
            return Ok(_authorRepository.GetQuery());
        }

        /// <summary>
        ///     Get all books of author
        /// </summary>
        /// <param name="id">Author's identifier</param>
        /// <returns></returns>
        [Route("~/api/v2/authors/{id:guid}/books")]
        [ResponseType(typeof (List<BookReadModel>))]
        public override IHttpActionResult GetBooksByAuthor(Guid id)
        {
            return base.GetBooksByAuthor(id);
        }
    }
}