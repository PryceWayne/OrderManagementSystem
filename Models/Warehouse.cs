using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class Warehouse
    {
        [Key]
        public string Warehouse_ID { get; set; } // Primary Key

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Currency { get; set; }

        // Navigation Properties
        public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
        public ICollection<InboundOrders> InboundOrders { get; set; } = new List<InboundOrders>();
        public ICollection<FreightOutbound> FreightOutbounds { get; set; } = new List<FreightOutbound>();
        public ICollection<ParcelOutbound> ParcelOutbounds { get; set; } = new List<ParcelOutbound>();
    }
}
