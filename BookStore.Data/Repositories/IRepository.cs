using System;
using System.Collections.Generic;

namespace BookStore.Data.Repositories
{
    public interface IRepository<T>
    {
        IList<T> GetList();
        T Find(Guid id);
        Guid Add(T author);
        void Update(T author);
        void Remove(Guid id);
    }
}