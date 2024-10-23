using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class Inventory
    {
        [Key]
        public string ProductId { get; set; } 

        [Required]
        public string WarehouseId { get; set; } 

        [StringLength(50)]
        public string SKU { get; set; }

        [StringLength(255)]
        public string ProductName { get; set; } 

        [StringLength(255)]
        public string ProductDescription { get; set; } 

        // Navigation Properties
        public Warehouse Warehouse { get; set; }

        public ICollection<FreightProductList> FreightProductLists { get; set; } = new List<FreightProductList>();
        public ICollection<InboundProductList> InboundProductLists { get; set; } = new List<InboundProductList>();
        public ICollection<ParcelProductList> ParcelProductLists { get; set; } = new List<ParcelProductList>();
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}