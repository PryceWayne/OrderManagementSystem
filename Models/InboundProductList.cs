using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementSystem.Models
{
    public class InboundProductList
    {
        public string Order_ID { get; set; } // Foreign Key to InboundOrders
        public string Product_ID { get; set; } // Foreign Key to Inventory

        public int Quantity { get; set; }

        // Navigation Properties
        public InboundOrders InboundOrder { get; set; }
        public Inventory Inventory { get; set; }
    }
}