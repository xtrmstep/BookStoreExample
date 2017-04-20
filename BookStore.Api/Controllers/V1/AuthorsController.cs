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
    ///     Information about authors
    /// </summary>
    public class AuthorsController : ApiController
    {
        protected readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        /// <summary>
        ///     constructor
        /// </summary>
        /// <param name="authorRepository"></param>
        /// <param name="bookRepository"></param>
        public AuthorsController(IAuthorRepository authorRepository, IBookRepository bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }

        /// <summary>
        ///     Get list of all authors
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof (List<AuthorReadModel>))]
        public virtual IHttpActionResult Get()
        {
            var listOfAuthors = _authorRepository.GetList();
            var authors = Mapper.Map<List<AuthorReadModel>>(listOfAuthors);
            return Ok(authors);
        }

        /// <summary>
        ///     Get information about author
        /// </summary>
        /// <param name="id">Author's identifier</param>
        /// <returns></returns>
        [ResponseType(typeof (AuthorReadModel))]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Not Found")]
        public IHttpActionResult Get(Guid id)
        {
            var author = _authorRepository.Find(id);
            if (author == null)
                return NotFound();

            var authorViewModel = Mapper.Map<AuthorReadModel>(author);
            return Ok(authorViewModel);
        }

        /// <summary>
        ///     Add new author
        /// </summary>
        /// <param name="authorModel">Author create model</param>
        /// <returns></returns>
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Created", Type = typeof (Guid))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "BadRequest")]
        public IHttpActionResult Post([FromBody] AuthorCreateModel authorModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var newAuthor = Mapper.Map<Author>(authorModel);
            // add existing books
            foreach (var bookId in authorModel.Books)
            {
                var existingBook = _bookRepository.Find(bookId);
                if (existingBook != null)
                    newAuthor.Books.Add(existingBook);
            }
            var id = _authorRepository.Add(newAuthor);
            var location = new Uri(Request.RequestUri + "/" + id);
            return Created(location, id);
        }

        /// <summary>
        ///     Update author
        /// </summary>
        /// <param name="id">Author's identifier</param>
        /// <param name="authorModel">Author update model</param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "BadRequest")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Not Found")]
        public IHttpActionResult Put(Guid id, [FromBody] AuthorUpdateModel authorModel)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                var updatedAuthor = Mapper.Map<Author>(authorModel);
                updatedAuthor.Id = id;
                _authorRepository.Update(updatedAuthor);
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        /// <summary>
        ///     Delete author
        /// </summary>
        /// <param name="id">Author's identifier</param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Not Found")]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                _authorRepository.Remove(id);
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        /// <summary>
        ///     Get all books of author
        /// </summary>
        /// <param name="id">Author's identifier</param>
        /// <returns></returns>
        [Route("~/api/v1/authors/{id:guid}/books")]
        [ResponseType(typeof (List<BookReadModel>))]
        public virtual IHttpActionResult GetBooksByAuthor(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}