namespace OrderManagementSystem.Models
{
    public class BillingAccount
    {
        public string Billing_Account_ID { get; set; }  // Unique ID for the billing account (Primary Key)
        public string User_ID { get; set; }              // Foreign key reference to User
        public double Account_Balance { get; set; }      // Balance amount

        // Navigation property to User
        public User User { get; set; }                   // Assuming you have a User class

        // Navigation property to Billing
        public ICollection<Billing> Billings { get; set; } // Collection of Billing records
    }
}