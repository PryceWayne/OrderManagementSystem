using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class ParcelProductList
    {
        [Required]
        public string OrderId { get; set; } 

        [Required]
        public string ProductId { get; set; } 

        public int Quantity { get; set; }

        // Navigation Properties
        public ParcelOutbound ParcelOutbound { get; set; }
        public Inventory Inventory { get; set; }
    }
}