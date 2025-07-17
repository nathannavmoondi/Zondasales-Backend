using System.ComponentModel.DataAnnotations;

namespace ZondaAPI.Models
{
    public class ZondaCustomer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
} 