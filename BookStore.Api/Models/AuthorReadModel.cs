using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Models
{
    public class AuthorReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<BookReadModel> Books { get; set; } = new List<BookReadModel>();
    }
}