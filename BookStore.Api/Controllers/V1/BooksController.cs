using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using BookStore.Api.Models;
using BookStore.Data.Models;
using BookStore.Data.Repositories;
using Swashbuckle.Swagger.Annotations;

namespace BookStore.Api.Controllers.V1
{
    /// <summary>
    ///     Information about books
    /// </summary>
    public class BooksController : ApiController
    {
        protected readonly IBookRepository _bookRepository;

        /// <summary>
        ///     constructor
        /// </summary>
        /// <param name="bookRepository"></param>
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        /// <summary>
        ///     Get list of all books
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof (List<BookReadModel>))]
        public virtual IHttpActionResult Get()
        {
            var listOfBooks = _bookRepository.GetList();
            var books = Mapper.Map<List<BookReadModel>>(listOfBooks);
            return Ok(books);
        }

        /// <summary>
        ///     get information about one book
        /// </summary>
        /// <param name="id">Books' identifier</param>
        /// <returns></returns>
        [ResponseType(typeof (BookReadModel))]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Not Found")]
        public IHttpActionResult Get(Guid id)
        {
            var book = _bookRepository.Find(id);
            if (book == null)
                return NotFound();

            var bookViewModel = Mapper.Map<BookReadModel>(book);
            return Ok(bookViewModel);
        }

        /// <summary>
        ///     Add new book
        /// </summary>
        /// <param name="bookModel">Book create model</param>
        /// <returns></returns>
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Created", Type = typeof (Guid))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "BadRequest")]
        public IHttpActionResult Post([FromBody] BookCreateModel bookModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var newBook = Mapper.Map<Book>(bookModel);
            var id = _bookRepository.Add(newBook);
            var location = new Uri(Request.RequestUri + "/" + id);
            return Created(location, id);
        }

        /// <summary>
        ///     Update a book
        /// </summary>
        /// <param name="id">Book's identifier</param>
        /// <param name="bookModel">Book update model</param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "BadRequest")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Not Found")]
        public IHttpActionResult Put(Guid id, [FromBody] BookUpdateModel bookModel)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                var updatedBook = Mapper.Map<Book>(bookModel);
                updatedBook.Id = id;
                _bookRepository.Update(updatedBook);
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        /// <summary>
        ///     Delete a book
        /// </summary>
        /// <param name="id">Book's identifier</param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Not Found")]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                _bookRepository.Remove(id);
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
    }
}