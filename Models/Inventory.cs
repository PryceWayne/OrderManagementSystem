using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class Inventory
    {
        [Key]
        public string Product_ID { get; set; } // Primary Key

        [Required]
        public string Warehouse_ID { get; set; } // Foreign Key

        [StringLength(50)]
        public string SKU { get; set; }

        [StringLength(255)]
        public string Product_Name { get; set; }

        [StringLength(255)]
        public string Product_Description { get; set; }

        // Navigation property
        public Warehouse Warehouse { get; set; }

        public ICollection<FreightProductList> FreightProductLists { get; set; } = new List<FreightProductList>();
        public ICollection<InboundProductList> InboundProductLists { get; set; } = new List<InboundProductList>();
        public ICollection<ParcelProductList> ParcelProductLists { get; set; } = new List<ParcelProductList>();
    }
}