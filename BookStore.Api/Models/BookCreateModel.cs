using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Models
{
    public class BookCreateModel
    {
        [Required]
        public string Title { get; set; }
        public List<Guid> Authors { get; set; } = new List<Guid>();
    }
}