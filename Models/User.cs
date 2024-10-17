namespace OrderManagementSystem.Models
{
    public class User
    {
        public string User_ID { get; set; } // Primary Key
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime Date_Created { get; set; }

        public ICollection<Billing> Billings { get; set; } // A user can have multiple billings
        public ICollection<BillingAccount> BillingAccounts { get; set; } // A user can have multiple billing accounts
    }
}