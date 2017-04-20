using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Api.Models
{
    public class PublisherCreateModel
    {
        [Required]
        public string Name { get; set; }
        public List<Guid> Books { get; set; } = new List<Guid>();
        public List<Guid> Authors { get; set; } = new List<Guid>();
    }
}