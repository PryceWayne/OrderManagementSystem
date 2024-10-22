using System;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class Billing
    {
        [Key]
        public string Billing_ID { get; set; }  // Primary Key

        [Required]
        public string Billing_Account_ID { get; set; } // Foreign Key to BillingAccount

        public double Amount { get; set; }

        public DateTime DateCreated { get; set; }

        // Navigation property
        public BillingAccount BillingAccount { get; set; }
    }
}