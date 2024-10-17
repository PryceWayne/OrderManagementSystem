namespace OrderManagementSystem.Models
{
    public class InboundProductList
    {
        public string Order_ID { get; set; }  // Foreign key reference to InboundOrder
        public string Product_ID { get; set; } // Foreign key reference to Inventory
        public int Quantity { get; set; }

        public Inventory Inventory { get; set; } // Navigation property to Inventory
        public InboundOrder InboundOrder { get; set; } // Navigation property to InboundOrder
    }
}
