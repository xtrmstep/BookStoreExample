using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;
using System.Web.Http.Results;
using AutoMapper;
using BookStore.Api.Models;
using BookStore.Data;
using BookStore.Data.Models;
using BookStore.Data.Repositories;
using Swashbuckle.Swagger.Annotations;

namespace BookStore.Api.Controllers.V1
{
    public class AuthorsController : ApiController
    {
        protected readonly IAuthorRepository AuthorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            AuthorRepository = authorRepository;
        }

        [ResponseType(typeof(List<AuthorReadModel>))]
        public virtual IHttpActionResult Get()
        {
            var listOfAuthors = AuthorRepository.GetList();
            var authors = Mapper.Map<List<AuthorReadModel>>(listOfAuthors);
            return Ok(authors);
        }

        [ResponseType(typeof (AuthorReadModel))]
        public IHttpActionResult Get(Guid id)
        {
            var author = AuthorRepository.Find(id);
            if (author == null)
                return NotFound();

            var authorViewModel = Mapper.Map<AuthorReadModel>(author);
            return Ok(authorViewModel);
        }

        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Created", Type = typeof(Guid))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "BadRequest")]
        public IHttpActionResult Post([FromBody] AuthorCreateModel authorModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var newAuthor = Mapper.Map<Author>(authorModel);
            var id = AuthorRepository.Add(newAuthor);
            var location = new Uri(Request.RequestUri + "/" + id);
            return Created(location, id);
        }

        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "BadRequest")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Not Found")]
        public IHttpActionResult Put(Guid id, [FromBody] AuthorUpdateModel authorModel)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                var updatedAuthor = Mapper.Map<Author>(authorModel);
                updatedAuthor.Id = id;
                AuthorRepository.Update(updatedAuthor);
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Not Found")]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                AuthorRepository.Remove(id);
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
    }
}