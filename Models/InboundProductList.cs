using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class InboundProductList
    {
        [Required]
        public string OrderId { get; set; } 

        [Required]
        public string ProductId { get; set; } 

        public int Quantity { get; set; }

        // Navigation Properties
        public InboundOrder InboundOrder { get; set; }
        public Inventory Inventory { get; set; }
    }
}