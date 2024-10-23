using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class ParcelOutbound
    {
        [Key]
        public string OrderId { get; set; } // Changed from 'Order_ID'

        [StringLength(25)]
        public string OrderType { get; set; } // Changed from 'Order_Type'

        [StringLength(25)]
        public string OrderStatus { get; set; } // Changed from 'Order_Status'

        [Required]
        public string WarehouseId { get; set; } // Changed from 'Warehouse_ID'

        [Required]
        public string CreatorId { get; set; } // Changed from 'Creator'

        [StringLength(50)]
        public string Platform { get; set; }

        public DateTime EstimatedDeliveryDate { get; set; } // Changed from 'Estimated_Delivery_Date'

        public DateTime ShipDate { get; set; } // Changed from 'Ship_Date'

        public int TransportDays { get; set; } // Changed from 'Transport_Days'

        public double Cost { get; set; }

        [StringLength(25)]
        public string Currency { get; set; }

        [StringLength(50)]
        public string Recipient { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(25)]
        public string Postcode { get; set; }

        [StringLength(25)]
        public string TrackingNumber { get; set; } // Changed from 'Tracking_Number'

        [StringLength(25)]
        public string ReferenceOrderNumber { get; set; } // Changed from 'Reference_Order_Number'

        public DateTime CreationDate { get; set; } // Changed from 'Creation_Date'

        public int Boxes { get; set; }

        [StringLength(50)]
        public string ShippingCompany { get; set; }

        [StringLength(255)]
        public string LatestInformation { get; set; } 

        public DateTime TrackingUpdateTime { get; set; } 

        public DateTime InternetPostingTime { get; set; } 

        public DateTime DeliveryTime { get; set; } 

        [StringLength(25)]
        public string RelatedAdjustmentOrder { get; set; } 

        // Navigation Properties
        public Warehouse Warehouse { get; set; }
        public User Creator { get; set; }

        public ICollection<ParcelProductList> ParcelProductLists { get; set; } = new List<ParcelProductList>();
    }
}