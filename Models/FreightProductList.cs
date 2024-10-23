using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class FreightProductList
    {
        [Required]
        public string OrderId { get; set; } 

        [Required]
        public string ProductId { get; set; } 

        public int Quantity { get; set; }

        // Navigation Properties
        public FreightOutbound FreightOutbound { get; set; }
        public Inventory Inventory { get; set; }
    }
}