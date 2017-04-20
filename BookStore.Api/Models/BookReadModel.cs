using System;

namespace BookStore.Api.Models
{
    /// <summary>
    /// Book read model
    /// </summary>
    public class BookReadModel
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }
    }
}