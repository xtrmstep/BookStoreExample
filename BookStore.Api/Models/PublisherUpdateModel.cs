using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Models
{
    public class PublisherUpdateModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}