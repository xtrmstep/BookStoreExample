using System;
using System.Collections.Generic;

namespace BookStore.Data.Repositories
{
    public interface IRepository<T>
    {
        IList<T> GetList();
        T Find(Guid id);
        Guid Add(T author);

        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="author"></param>
        /// <exception cref="InvalidOperationException">No element satisfies the condition</exception>
        void Update(T author);

        /// <summary>
        /// Remove item
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="InvalidOperationException">No element satisfies the condition</exception>
        void Remove(Guid id);
    }
}