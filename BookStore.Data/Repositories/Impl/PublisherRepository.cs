using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Data.Models;

namespace BookStore.Data.Repositories.Impl
{
    class PublisherRepository : IPublisherRepository
    {
        public Guid Add(Publisher item)
        {
            using (var ctx = new BookStoreContext())
            {
                var addedPublisher = ctx.Publishers.Add(item);
                ctx.SaveChanges();
                return addedPublisher.Id;
            }
        }

        public Publisher Find(Guid id)
        {
            using (var ctx = new BookStoreContext())
            {
                return ctx.Publishers.FirstOrDefault(a => a.Id == id);
            }
        }

        public IList<Publisher> GetList()
        {
            using (var ctx = new BookStoreContext())
            {
                return ctx.Publishers.ToList();
            }
        }

        public IQueryable<Publisher> GetQuery()
        {
            return new BookStoreContext().Publishers.AsQueryable();
        }

        public void Remove(Guid id)
        {
            using (var ctx = new BookStoreContext())
            {
                var publisher = ctx.Publishers.First(a => a.Id == id);
                ctx.Publishers.Remove(publisher);
                ctx.SaveChanges();
            }
        }

        public void Update(Publisher item)
        {
            using (var ctx = new BookStoreContext())
            {
                var existingPublisher = ctx.Publishers.First(a => a.Id == item.Id);
                existingPublisher.Name = item.Name;
                ctx.SaveChanges();
            }
        }
    }
}