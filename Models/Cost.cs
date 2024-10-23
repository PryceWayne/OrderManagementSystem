using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class Cost
    {
        [Key]
        public string CostId { get; set; } 

        public double Amount { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
    }
}