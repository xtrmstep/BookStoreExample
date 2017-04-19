using System;
using System.Collections;
using System.Collections.Generic;
using BookStore.Data.Models;

namespace BookStore.Data.Repositories
{
    public interface IStoreRepository
    {
        IList<Store> GetList();
        Store Find(Guid id);
        Guid Add(Store newStore);
    }
}