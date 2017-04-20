using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Models
{
    public class BookUpdateModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}