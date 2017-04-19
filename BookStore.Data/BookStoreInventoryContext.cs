using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.Models;

namespace BookStore.Data
{
    interface IBookStoreInventoryContext
    {
        IDbSet<Author> Authors { get; set; }
        IDbSet<Book> Books { get; set; }
        IDbSet<Store> Stores { get; set; }
    }

    class BookStoreInventoryContext : IBookStoreInventoryContext
    {
    }
}
