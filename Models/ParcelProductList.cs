using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementSystem.Models
{
    public class ParcelProductList
    {
        public string Order_ID { get; set; } // Foreign Key to ParcelOutbound
        public string Product_ID { get; set; } // Foreign Key to Inventory

        public int Quantity { get; set; }

        // Navigation Properties
        public ParcelOutbound ParcelOutbound { get; set; }
        public Inventory Inventory { get; set; }
    }
}