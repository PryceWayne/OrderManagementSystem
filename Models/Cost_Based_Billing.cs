using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementSystem.Models
{
    public class Cost_Based_Billing
    {
        public string Billing_Account_ID { get; set; } // Foreign Key
        public string Cost_Charge_ID { get; set; }     // Foreign Key

        // Navigation Properties
        public BillingAccount BillingAccount { get; set; }
        public Cost_Based_Charges Cost_Based_Charges { get; set; }
    }
}