using BookStore.Api.Controllers.V1;
using BookStore.Data.Repositories;

namespace BookStore.Api.Controllers.V2
{
    public class BooksV2Controller : BooksV1Controller
    {
        public BooksV2Controller(IBookRepository bookRepository) : base(bookRepository)
        {
        }
    }
}