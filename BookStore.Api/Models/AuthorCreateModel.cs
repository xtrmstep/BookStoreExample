using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Models
{
    public class AuthorCreateModel
    {
        [Required]
        public string Name { get; set; }
    }
}