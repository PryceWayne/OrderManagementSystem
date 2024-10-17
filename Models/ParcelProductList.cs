namespace OrderManagementSystem.Models
{
    public class ParcelProductList
    {
        public string Order_ID { get; set; }  // Composite key part 1
        public string Product_ID { get; set; } // Composite key part 2
        public int Quantity { get; set; }      // Quantity of the product in the order

        // Navigation properties
        public ParcelOutbound ParcelOutbound { get; set; } // Relationship to ParcelOutbound
        public Inventory Inventory { get; set; }           // Relationship to Inventory
    }
}