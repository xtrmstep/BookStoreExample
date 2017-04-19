using System.Collections.Generic;

namespace BookStore.Data.Models
{
    public class Author : Entity
    {
        public string Name { get; set; }
        public IList<Book> Books { get; set; } = new List<Book>();
    }
}