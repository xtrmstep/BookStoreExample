using System.Collections;
using BookStore.Data.Models;
using System.Collections.Generic;
using System;

namespace BookStore.Data.Repositories
{
    public interface IBookRepository: IRepository<Book>
    {
    }
}