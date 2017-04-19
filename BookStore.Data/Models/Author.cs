using System.Collections.Generic;

namespace BookStore.Data.Models
{
    public class Author : Entity
    {
        /// <summary>
        ///     Author full name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Books of the author
        /// </summary>
        public IList<Book> Books { get; set; } = new List<Book>();
    }
}