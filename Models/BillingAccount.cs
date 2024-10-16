namespace OrderManagementSystem.Models
{
    public class BillingAccount
    {
        public string Billing_Account_ID { get; set; } // Primary Key
        public string User_ID { get; set; }
        public double Account_Balance { get; set; }

        public User User { get; set; }  // Navigation property
    }
}