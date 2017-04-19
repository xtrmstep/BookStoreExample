using System;
using System.Collections;
using System.Collections.Generic;
using BookStore.Data.Models;

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

    public interface IAuthorRepository : IRepository<Author>
    {
        IList<Author> GetList();
        Author Find(Guid id);
        Guid Add(Author author);
        void Update(Author author);
        void Remove(Guid id);
    }
}
