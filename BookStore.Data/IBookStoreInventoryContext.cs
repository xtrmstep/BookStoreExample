using System.Data.Entity;
using BookStore.Data.Models;

namespace BookStore.Data
{
    interface IBookStoreInventoryContext
    {
        IDbSet<Author> Authors { get; set; }
        IDbSet<Book> Books { get; set; }
        IDbSet<Store> Stores { get; set; }
        IDbSet<Publisher> Publishers { get; set; }
    }
}