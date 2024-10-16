namespace OrderManagementSystem.Models
{
    public class CostBasedBilling
    {
        public string Billing_Account_ID { get; set; }
        public string Cost_Charge_ID { get; set; }

        public BillingAccount BillingAccount { get; set; } // Navigation property
        public CostBasedCharge CostCharge { get; set; } // Navigation property
    }
}
