using System.Collections.Generic;

namespace BookStore.Data.Models
{
    public class Store : Entity
    {
        public string Name { get; set; }
        public LocationAddress Address { get; set; }
        public IList<Book> Books { get; set; } = new List<Book>();
        public IList<Author> Authors { get; set; } = new List<Author>();
        public IList<Publisher> Publishers { get; set; } = new List<Publisher>();
    }
}