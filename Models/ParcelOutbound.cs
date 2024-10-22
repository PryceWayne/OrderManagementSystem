using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class ParcelOutbound
    {
        [Key]
        public string Order_ID { get; set; }  // Primary Key

        [StringLength(25)]
        public string Order_Type { get; set; }

        [StringLength(25)]
        public string Order_Status { get; set; }

        [Required]
        public string Warehouse_ID { get; set; } // Foreign Key to Warehouse

        [Required]
        public string Creator { get; set; } // Foreign Key to User

        [StringLength(50)]
        public string Platform { get; set; }

        public DateTime Estimated_Delivery_Date { get; set; }

        public DateTime Ship_Date { get; set; }

        public int Transport_Days { get; set; }

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
        public string Tracking_Number { get; set; }

        [StringLength(25)]
        public string Reference_Order_Number { get; set; }

        public DateTime Creation_Date { get; set; }

        public int Boxes { get; set; }

        [StringLength(50)]
        public string Shipping_Company { get; set; }

        [StringLength(255)]
        public string Latest_Information { get; set; }

        public DateTime Tracking_Update_Time { get; set; }

        public DateTime Internet_Posting_Time { get; set; }

        public DateTime Delivery_Time { get; set; }

        [StringLength(25)]
        public string Related_Adjustment_Order { get; set; }

        // Navigation Properties
        public Warehouse Warehouse { get; set; }
        public User User { get; set; } // Assuming you have a navigation property to User

        public ICollection<ParcelProductList> ParcelProductLists { get; set; } = new List<ParcelProductList>();
    }
}