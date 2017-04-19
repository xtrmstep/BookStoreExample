using System;

namespace BookStore.Api.Models
{
    public class BookReadModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}