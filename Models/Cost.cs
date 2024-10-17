namespace OrderManagementSystem.Models
{
    public class Cost
    {
        public string Cost_ID { get; set; } // Primary key

        public double Amount { get; set; }
        public string Description { get; set; }

        // You can add navigation properties if necessary
    }
}