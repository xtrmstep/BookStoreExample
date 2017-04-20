using System.Collections;
using System.Linq;
using BookStore.Data.Models;

namespace BookStore.Data.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        IQueryable<Author> GetQuery();
    }
}
