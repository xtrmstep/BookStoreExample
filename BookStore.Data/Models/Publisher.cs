using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Models
{
    public class Publisher : Entity
    {
        public string Name { get; set; }
        public IList<Book> Books { get; set; } = new List<Book>();
        public IList<Author> Authors { get; set; } = new List<Author>();
    }
}
