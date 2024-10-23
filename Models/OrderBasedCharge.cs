using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class OrderBasedCharge
    {
        [Key]
        public string OrderChargeId { get; set; } 

        public double? Amount { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
    }
}