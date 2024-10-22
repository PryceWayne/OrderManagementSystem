using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class Cost_Based_Charges
    {
        [Key]
        public string Cost_Charge_ID { get; set; } // Primary Key

        public double? Amount { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
    }
}