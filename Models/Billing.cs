namespace OrderManagementSystem.Models
{
    public class Billing
    {
        public string Billing_ID { get; set; }  // Unique ID for the Billing record (Primary Key)
        public string Billing_Account_ID { get; set; } // Foreign key reference to BillingAccount
        public double Amount { get; set; } // Amount to bill
        public DateTime DateCreated { get; set; } // When the billing was created

        // Navigation property to BillingAccount
        public BillingAccount BillingAccount { get; set; }
    }
}