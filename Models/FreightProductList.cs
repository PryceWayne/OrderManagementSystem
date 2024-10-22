using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementSystem.Models
{
    public class FreightProductList
    {
        public string Order_ID { get; set; } // Foreign Key to FreightOutbound
        public string Product_ID { get; set; } // Foreign Key to Inventory

        public int Quantity { get; set; }

        // Navigation Properties
        public FreightOutbound FreightOutbound { get; set; }
        public Inventory Inventory { get; set; }
    }
}