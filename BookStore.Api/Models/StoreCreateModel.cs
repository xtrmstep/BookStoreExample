using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Models
{
    public class StoreCreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public LocationAddressModel Address { get; set; }
        public List<Guid> Books { get; set; } = new List<Guid>();
        public List<Guid> Authors { get; set; } = new List<Guid>();
        public List<Guid> Publishers { get; set; } = new List<Guid>();
    }
}