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
    [RoutePrefix("api/v1/books")]
    public class BooksController : ApiController
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [ResponseType(typeof(List<BookReadModel>))]
        public IHttpActionResult Get()
        {
            var listOfBooks = _bookRepository.GetList();
            var books = Mapper.Map<List<BookReadModel>>(listOfBooks);
            return Ok(books);
        }

        [Route("{id:guid}")]
        [ResponseType(typeof(BookReadModel))]
        public IHttpActionResult Get(Guid id)
        {
            var book = _bookRepository.Find(id);
            if (book == null)
                return NotFound();

            var bookViewModel = Mapper.Map<BookReadModel>(book);
            return Ok(bookViewModel);
        }

        public IHttpActionResult Post([FromBody]BookCreateModel bookModel)
        {
            var newBook = Mapper.Map<Book>(bookModel);
            var id = _bookRepository.Add(newBook);
            var location = new Uri(Request.RequestUri + "/" + id);
            return Created(location, id);
        }

        public IHttpActionResult Put(int id, [FromBody]string value)
        {
        }

        public IHttpActionResult Delete(int id)
        {
        }
    }
}
