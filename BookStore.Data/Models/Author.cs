using System.Collections.Generic;

namespace BookStore.Data.Models
{
    /// <summary>
    /// Author data model
    /// </summary>
    public class Author : Entity
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        public IList<Book> Books { get; set; } = new List<Book>();
    }
}