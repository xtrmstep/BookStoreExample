using BookStore.Api.Controllers.V1;
using BookStore.Data.Repositories;

namespace BookStore.Api.Controllers.V2
{
    public class BooksController : V1.BooksController
    {
        public BooksController(IBookRepository bookRepository) : base(bookRepository)
        {
        }
    }
}