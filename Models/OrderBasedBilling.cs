namespace OrderManagementSystem.Models
{
    public class OrderBasedBilling
    {
        public string Billing_Account_ID { get; set; }
        public string Order_Charge_ID { get; set; }

        public BillingAccount BillingAccount { get; set; } // Navigation property
        public OrderBasedCharge OrderCharge { get; set; } // Navigation property
    }
}
