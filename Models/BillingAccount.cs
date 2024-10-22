using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class BillingAccount
    {
        [Key]
        public string Billing_Account_ID { get; set; }  // Primary Key

        [Required]
        public string User_ID { get; set; }  // Foreign key to User

        public double Account_Balance { get; set; }

        // Navigation properties
        public User User { get; set; }

        public ICollection<Billing> Billings { get; set; } = new List<Billing>();
        public ICollection<Cost_Based_Billing> Cost_Based_Billings { get; set; } = new List<Cost_Based_Billing>();
        public ICollection<Order_Based_Billing> Order_Based_Billings { get; set; } = new List<Order_Based_Billing>();
    }
}