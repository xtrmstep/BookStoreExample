using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Models
{
    public class StoreUpdateModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public LocationAddressModel Address { get; set; }
    }
}