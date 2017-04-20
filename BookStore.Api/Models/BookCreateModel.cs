using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Models
{
    /// <summary>
    /// Book create model
    /// </summary>
    public class BookCreateModel
    {
        /// <summary>
        /// Title
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// All authors of the book
        /// </summary>
        public List<Guid> Authors { get; set; } = new List<Guid>();
    }
}