using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Models
{
    public class LocationAddress : Entity
    {
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}
