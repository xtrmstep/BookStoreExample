using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Data.Repositories
{
    public interface IRepository<T>
    {
        IList<T> GetList();
        T Find(Guid id);
        Guid Add(T item);

        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="InvalidOperationException">No element satisfies the condition</exception>
        void Update(T item);

        /// <summary>
        /// Remove item
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="InvalidOperationException">No element satisfies the condition</exception>
        void Remove(Guid id);
        IQueryable<T> GetQuery();
    }
}