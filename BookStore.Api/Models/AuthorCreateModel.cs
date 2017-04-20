using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Models
{
    /// <summary>
    /// Author create model
    /// </summary>
    public class AuthorCreateModel
    {
        /// <summary>
        /// Author name
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// All books of the author
        /// </summary>
        public List<Guid> Books { get; set; } = new List<Guid>();
    }
}