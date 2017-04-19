using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Data.Models;

namespace BookStore.Data.Repositories.Impl
{
    class AuthorRepository : IAuthorRepository
    {
        public Guid Add(Author author)
        {
            using (var ctx = new BookStoreContext())
            {
                var addedAuthor = ctx.Authors.Add(author);
                ctx.SaveChanges();
                return addedAuthor.Id;
            }
        }

        public Author Find(Guid id)
        {
            using (var ctx = new BookStoreContext())
            {
                return ctx.Authors.FirstOrDefault(a => a.Id == id);
            }
        }

        public IList<Author> GetList()
        {
            using (var ctx = new BookStoreContext())
            {
                return ctx.Authors.ToList();
            }
        }

        public void Remove(Guid id)
        {
            using (var ctx = new BookStoreContext())
            {
                var author = ctx.Authors.First(a => a.Id == id);
                ctx.Authors.Remove(author);
                ctx.SaveChanges();
            }
        }

        public void Update(Author author)
        {
            using (var ctx = new BookStoreContext())
            {
                var existingAuthor = ctx.Authors.First(a => a.Id == author.Id);
                existingAuthor.Name = author.Name;
                ctx.SaveChanges();
            }
        }
    }
}
