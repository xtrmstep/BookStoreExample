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
    public class BooksV1Controller : ApiController
    {
        private readonly IBookRepository _bookRepository;

        public BooksV1Controller(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [ResponseType(typeof (List<BookReadModel>))]
        public IHttpActionResult Get()
        {
            var listOfBooks = _bookRepository.GetList();
            var books = Mapper.Map<List<BookReadModel>>(listOfBooks);
            return Ok(books);
        }

        [ResponseType(typeof (BookReadModel))]
        public IHttpActionResult Get(Guid id)
        {
            var book = _bookRepository.Find(id);
            if (book == null)
                return NotFound();

            var bookViewModel = Mapper.Map<BookReadModel>(book);
            return Ok(bookViewModel);
        }

        public IHttpActionResult Post([FromBody] BookCreateModel bookModel)
        {
            var newBook = Mapper.Map<Book>(bookModel);
            var id = _bookRepository.Add(newBook);
            var location = new Uri(Request.RequestUri + "/" + id);
            return Created(location, id);
        }

        public IHttpActionResult Put(Guid id, [FromBody] BookUpdateModel bookModel)
        {
            var updatedBook = Mapper.Map<Book>(bookModel);
            updatedBook.Id = id;
            _bookRepository.Update(updatedBook);
            return Ok();
        }

        public IHttpActionResult Delete(Guid id)
        {
            _bookRepository.Remove(id);
            return Ok();
        }
    }
}