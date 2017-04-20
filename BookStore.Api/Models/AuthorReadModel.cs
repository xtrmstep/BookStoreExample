using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Models
{
    /// <summary>
    /// Author read model
    /// </summary>
    public class AuthorReadModel
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// All books of the author
        /// </summary>
        public List<BookReadModel> Books { get; set; } = new List<BookReadModel>();
    }
}