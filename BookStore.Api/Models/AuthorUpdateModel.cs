using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Models
{
    /// <summary>
    /// Author update model
    /// </summary>
    public class AuthorUpdateModel
    {
        /// <summary>
        /// Identifier
        /// </summary>
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}