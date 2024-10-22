using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class Order_Based_Charges
    {
        [Key]
        public string Order_Charge_ID { get; set; } // Primary Key

        public double? Amount { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
    }
}