using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class FreightOutbound
    {
        [Key]
        public string OutboundOrderId { get; set; } 

        [StringLength(25)]
        public string OrderType { get; set; } 

        [StringLength(25)]
        public string OrderStatus { get; set; } 

        [Required]
        public string CreatorId { get; set; } 

        [Required]
        public string WarehouseId { get; set; } 

        public int ProductQuantity { get; set; } 

        public DateTime CreationDate { get; set; } 

        public DateTime EstimatedDeliveryDate { get; set; } 

        public DateTime OrderShipDate { get; set; } 

        public double Cost { get; set; }

        [StringLength(50)]
        public string Currency { get; set; }

        [StringLength(100)]
        public string Recipient { get; set; }

        [StringLength(50)]
        public string RecipientPostCode { get; set; } 

        [StringLength(50)]
        public string DestinationType { get; set; } 

        [StringLength(50)]
        public string Platform { get; set; }

        [StringLength(50)]
        public string ShippingCompany { get; set; }

        public int TransportDays { get; set; } 

        [StringLength(25)]
        public string RelatedAdjustmentOrder { get; set; } 

        [StringLength(255)]
        public string TrackingNumber { get; set; } 

        [StringLength(255)]
        public string ReferenceOrderNumber { get; set; } 

        [StringLength(25)]
        public string OutboundMethod { get; set; } 

        // Navigation Properties
        public Warehouse Warehouse { get; set; }
        public User Creator { get; set; }

        public ICollection<FreightProductList> FreightProductLists { get; set; } = new List<FreightProductList>();
    }
}