using System;

namespace BookStore.Api.Models
{
    public class StoreReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public LocationAddressModel Address { get; set; }
    }
}