using System;
using System.Data.Entity;
using BookStore.Data.Models;

namespace BookStore.Data.Impl
{
    class BookStoreInventoryContext : DbContext, IBookStoreInventoryContext
    {
        public IDbSet<Author> Authors { get; set; }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Publisher> Publishers { get; set; }

        public IDbSet<Store> Stores { get; set; }
    }
}
