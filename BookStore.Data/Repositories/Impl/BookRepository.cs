using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Data.Models;

namespace BookStore.Data.Repositories.Impl
{
    class BookRepository : IBookRepository
    {
        public Guid Add(Book item)
        {
            using (var ctx = new BookStoreContext())
            {
                var addedBook = ctx.Books.Add(item);
                ctx.SaveChanges();
                return addedBook.Id;
            }
        }

        public Book Find(Guid id)
        {
            using (var ctx = new BookStoreContext())
            {
                return ctx.Books.FirstOrDefault(a => a.Id == id);
            }
        }

        public IList<Book> GetList()
        {
            using (var ctx = new BookStoreContext())
            {
                return ctx.Books.ToList();
            }
        }

        public IQueryable<Book> GetQuery()
        {
            return new BookStoreContext().Books.AsQueryable();
        }

        public void Remove(Guid id)
        {
            using (var ctx = new BookStoreContext())
            {
                var book = ctx.Books.First(a => a.Id == id);
                ctx.Books.Remove(book);
                ctx.SaveChanges();
            }
        }

        public void Update(Book item)
        {
            using (var ctx = new BookStoreContext())
            {
                var existingBook = ctx.Books.First(a => a.Id == item.Id);
                existingBook.Title = item.Title;
                ctx.SaveChanges();
            }
        }
    }
}