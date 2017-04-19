using BookStore.Data.Models;
using System.Collections;
using System.Collections.Generic;
using System;

namespace BookStore.Data.Repositories
{
    public interface IPublisherRepository
    {
        IList<Publisher> GetList();
        Publisher Find(Guid id);
        Guid Add(Publisher newPublisher);
    }
}