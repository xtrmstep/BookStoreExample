using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Data.Models;

namespace BookStore.Data.Repositories.Impl
{
    class StoreRepository : IStoreRepository
    {
        public Guid Add(Store item)
        {
            using (var ctx = new BookStoreContext())
            {
                var addedStore = ctx.Stores.Add(item);
                ctx.SaveChanges();
                return addedStore.Id;
            }
        }

        public Store Find(Guid id)
        {
            using (var ctx = new BookStoreContext())
            {
                return ctx.Stores.FirstOrDefault(a => a.Id == id);
            }
        }

        public IList<Store> GetList()
        {
            using (var ctx = new BookStoreContext())
            {
                return ctx.Stores.ToList();
            }
        }

        public void Remove(Guid id)
        {
            using (var ctx = new BookStoreContext())
            {
                var store = ctx.Stores.First(a => a.Id == id);
                ctx.Stores.Remove(store);
                ctx.SaveChanges();
            }
        }

        public void Update(Store item)
        {
            using (var ctx = new BookStoreContext())
            {
                var existingStore = ctx.Stores.First(a => a.Id == item.Id);
                existingStore.Name = item.Name;
                ctx.SaveChanges();
            }
        }
    }
}