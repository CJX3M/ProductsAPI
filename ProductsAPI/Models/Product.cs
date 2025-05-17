using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = null;

        [MaxLength(500)]
        public string? Description { get; set; } = null;

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [ConcurrencyCheck]
        public int Stock { get; set; }

    }
}
