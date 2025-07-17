using System.ComponentModel.DataAnnotations;

namespace ZondaAPI.Models
{
    public class ZondaProduct
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
} 