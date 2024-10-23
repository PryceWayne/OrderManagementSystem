using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class CostBasedCharge
    {
        [Key]
        public string CostChargeId { get; set; } 

        public double? Amount { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
    }
}