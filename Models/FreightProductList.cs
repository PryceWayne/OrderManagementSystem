namespace OrderManagementSystem.Models
{
    public class FreightProductList
    {
        public string Order_ID { get; set; }
        public string Product_ID { get; set; }
        public int Quantity { get; set; }

        public Inventory Inventory { get; set; } // Navigation property
        public FreightOutbound FreightOutbound { get; set; } // Navigation property

    }
}
