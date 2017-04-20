using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Data.Models;

namespace BookStore.Data.Repositories.Impl
{
    class AuthorRepository : IAuthorRepository
    {
        public IQueryable<Author> GetQuery()
        {
            return new BookStoreContext().Authors.AsQueryable();
        }

        public Guid Add(Author item)
        {
            using (var ctx = new BookStoreContext())
            {
                var addedAuthor = ctx.Authors.Add(item);
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

        public void Update(Author item)
        {
            using (var ctx = new BookStoreContext())
            {
                var existingAuthor = ctx.Authors.First(a => a.Id == item.Id);
                existingAuthor.Name = item.Name;
                ctx.SaveChanges();
            }
        }
    }
}
