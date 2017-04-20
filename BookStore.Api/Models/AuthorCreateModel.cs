using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Models
{
    public class AuthorCreateModel
    {
        [Required]
        public string Name { get; set; }
        public List<Guid> Books { get; set; } = new List<Guid>();
    }
}