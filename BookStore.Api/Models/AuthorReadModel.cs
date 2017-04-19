using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Models
{
    public class AuthorReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}