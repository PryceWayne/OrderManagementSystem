using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementSystem.Models
{
    public class Order_Based_Billing
    {
        public string Billing_Account_ID { get; set; } // Foreign Key
        public string Order_Charge_ID { get; set; }    // Foreign Key

        // Navigation Properties
        public BillingAccount BillingAccount { get; set; }
        public Order_Based_Charges Order_Based_Charges { get; set; }
    }
}