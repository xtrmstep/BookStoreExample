using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Models
{
    public class AuthorUpdateModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}