using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Api.Models
{
    public class LocationAddressModel
    {
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}