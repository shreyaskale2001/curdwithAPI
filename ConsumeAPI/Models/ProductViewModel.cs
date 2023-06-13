using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsumeAPI.Models
{
    public class ProductViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Qty { get; set; }
    }
}
