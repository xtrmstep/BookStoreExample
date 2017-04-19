using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using BookStore.Api.Models;
using BookStore.Data.Models;
using BookStore.Data.Repositories;

namespace BookStore.Api.Controllers.V1
{
    [RoutePrefix("api/v1/authors")]
    public class AuthorsController : ApiController
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [ResponseType(typeof(List<AuthorReadModel>))]
        public IHttpActionResult Get()
        {
            var listOfAuthors = _authorRepository.GetList();
            var authors = Mapper.Map<List<AuthorReadModel>>(listOfAuthors);
            return Ok(authors);
        }

        [Route("{id:guid}")]
        [ResponseType(typeof(AuthorReadModel))]
        public IHttpActionResult Get(Guid id)
        {
            var author = _authorRepository.Find(id);
            if (author == null)
                return NotFound();

            var authorViewModel = Mapper.Map<AuthorReadModel>(author);
            return Ok(authorViewModel);
        }

        public IHttpActionResult Post([FromBody]AuthorCreateModel authorModel)
        {
            var newAuthor = Mapper.Map<Author>(authorModel);
            var id = _authorRepository.Add(newAuthor);
            var location = new Uri(Request.RequestUri + "/" + id);
            return Created(location, id);
        }

        public IHttpActionResult Put(int id, [FromBody]AuthorUpdateModel authorModel)
        {
            var updatedAuthor = Mapper.Map<Author>(authorModel);
            _authorRepository.Update(updatedAuthor);
            return Ok();
        }

        [Route("{id:guid}")]
        public IHttpActionResult Delete(Guid id)
        {
            _authorRepository.Remove(id);
            return Ok();
        }
    }
}