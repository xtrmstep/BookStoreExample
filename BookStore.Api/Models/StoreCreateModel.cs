using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Models
{
    public class StoreCreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public LocationAddressModel Address { get; set; }
    }
}