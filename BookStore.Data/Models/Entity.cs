using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Data.Models
{
    public abstract class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
}