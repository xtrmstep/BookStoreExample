using System.Collections.Generic;

namespace BookStore.Data.Models
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public IList<Author> Authors { get; set; } = new List<Author>();
    }
}