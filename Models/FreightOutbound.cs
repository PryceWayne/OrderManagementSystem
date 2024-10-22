using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class FreightOutbound
    {
        [Key]
        public string Outbound_Order_ID { get; set; } // Primary Key

        [StringLength(25)]
        public string Order_Type { get; set; }

        [StringLength(25)]
        public string Order_Status { get; set; }

        [Required]
        public string Creator { get; set; } // Foreign Key to User

        [Required]
        public string Warehouse_ID { get; set; } // Foreign Key to Warehouse

        public int Product_Quantity { get; set; }

        public DateTime Creation_Date { get; set; }

        public DateTime Estimated_Delivery_Date { get; set; }

        public DateTime Order_Ship_Date { get; set; }

        public double Cost { get; set; }

        [StringLength(50)]
        public string Currency { get; set; }

        [StringLength(100)]
        public string Recipient { get; set; }

        [StringLength(50)]
        public string Recipient_Post_Code { get; set; }

        [StringLength(50)]
        public string Destination_Type { get; set; }

        [StringLength(50)]
        public string Platform { get; set; }

        [StringLength(50)]
        public string Shipping_Company { get; set; }

        public int Transport_Days { get; set; }

        [StringLength(25)]
        public string Related_Adjustment_Order { get; set; }

        [StringLength(255)]
        public string Tracking_Number { get; set; }

        [StringLength(255)]
        public string Reference_Order_Number { get; set; }

        [StringLength(25)]
        public string FBA_Shipment_ID { get; set; }

        [StringLength(25)]
        public string FBA_Tracking_Number { get; set; }

        [StringLength(25)]
        public string Outbound_Method { get; set; }

        // Navigation Properties
        public Warehouse Warehouse { get; set; }
        public User User { get; set; } // Assuming you have a navigation property to User

        public ICollection<FreightProductList> FreightProductLists { get; set; } = new List<FreightProductList>();
    }
}