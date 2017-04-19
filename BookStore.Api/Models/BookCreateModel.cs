using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Models
{
    public class BookCreateModel
    {
        [Required]
        public string Title { get; set; }
    }
}