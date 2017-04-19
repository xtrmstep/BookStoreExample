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
    public class AuthorsV1Controller : ApiController
    {
        protected readonly IAuthorRepository AuthorRepository;

        public AuthorsV1Controller(IAuthorRepository authorRepository)
        {
            AuthorRepository = authorRepository;
        }

        [ResponseType(typeof(List<AuthorReadModel>))]
        public IHttpActionResult Get()
        {
            var listOfAuthors = AuthorRepository.GetList();
            var authors = Mapper.Map<List<AuthorReadModel>>(listOfAuthors);
            return Ok(authors);
        }

        [ResponseType(typeof(AuthorReadModel))]
        public IHttpActionResult Get(Guid id)
        {
            var author = AuthorRepository.Find(id);
            if (author == null)
                return NotFound();

            var authorViewModel = Mapper.Map<AuthorReadModel>(author);
            return Ok(authorViewModel);
        }

        public IHttpActionResult Post([FromBody]AuthorCreateModel authorModel)
        {
            var newAuthor = Mapper.Map<Author>(authorModel);
            var id = AuthorRepository.Add(newAuthor);
            var location = new Uri(Request.RequestUri + "/" + id);
            return Created(location, id);
        }

        public IHttpActionResult Put(int id, [FromBody]AuthorUpdateModel authorModel)
        {
            var updatedAuthor = Mapper.Map<Author>(authorModel);
            AuthorRepository.Update(updatedAuthor);
            return Ok();
        }

        public IHttpActionResult Delete(Guid id)
        {
            AuthorRepository.Remove(id);
            return Ok();
        }
    }
}