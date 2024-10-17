using System;

namespace OrderManagementSystem.Models
{
    public class FreightProductList
    {
        public string Order_ID { get; set; } // Foreign key reference to FreightOutbound
        public string Product_ID { get; set; } // Foreign key reference to Inventory
        public int Quantity { get; set; } // Quantity of the product in the order

        // Navigation properties
        public FreightOutbound FreightOutbound { get; set; } // Relationship to FreightOutbound
        public Inventory Inventory { get; set; } // Relationship to Inventory
    }
}