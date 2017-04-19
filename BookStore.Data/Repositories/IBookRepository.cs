using System.Collections;
using BookStore.Data.Models;
using System.Collections.Generic;
using System;

namespace BookStore.Data.Repositories
{
    public interface IBookRepository: IRepository<Book>
    {
        IList<Book> GetList();
        Book Find(Guid id);
        Guid Add(Book newBook);
    }
}