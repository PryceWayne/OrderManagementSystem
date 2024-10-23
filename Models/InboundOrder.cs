using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class InboundOrder
    {
        [Key]
        public string InboundOrderId { get; set; } // Changed from 'Inbound_Order_ID'

        [StringLength(25)]
        public string OrderStatus { get; set; } // Changed from 'Order_Status'

        [Required]
        public string CreatorId { get; set; } // Changed from 'Creator'

        [Required]
        public string WarehouseId { get; set; } // Changed from 'Warehouse_ID'

        public DateTime EstimatedArrival { get; set; } // Changed from 'Estimated_Arrival'

        public int ProductQuantity { get; set; } // Changed from 'Product_Quantity'

        public DateTime CreationDate { get; set; } // Changed from 'Creation_Date'

        public double Cost { get; set; }

        [StringLength(50)]
        public string Currency { get; set; }

        public int Boxes { get; set; }

        [StringLength(25)]
        public string InboundType { get; set; } 

        [StringLength(255)]
        public string TrackingNumber { get; set; } 

        [StringLength(255)]
        public string ReferenceOrderNumber { get; set; } 

        [StringLength(25)]
        public string ArrivalMethod { get; set; } 

        // Navigation Properties
        public Warehouse Warehouse { get; set; }
        public User Creator { get; set; }

        public ICollection<InboundProductList> InboundProductLists { get; set; } = new List<InboundProductList>();
    }
}