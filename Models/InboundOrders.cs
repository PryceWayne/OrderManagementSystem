using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class InboundOrders
    {
        [Key]
        public string Inbound_Order_ID { get; set; } // Primary Key

        [StringLength(25)]
        public string Order_Status { get; set; }

        [Required]
        public string Creator { get; set; } // Foreign Key to User

        [Required]
        public string Warehouse_ID { get; set; } // Foreign Key to Warehouse

        public DateTime Estimated_Arrival { get; set; }

        public int Product_Quantity { get; set; }

        public DateTime Creation_Date { get; set; }

        public double Cost { get; set; }

        [StringLength(50)]
        public string Currency { get; set; }

        public int Boxes { get; set; }

        [StringLength(25)]
        public string Inbound_Type { get; set; }

        [StringLength(255)]
        public string Tracking_Number { get; set; }

        [StringLength(255)]
        public string Reference_Order_Number { get; set; }

        [StringLength(25)]
        public string Arrival_Method { get; set; }

        // Navigation Properties
        public Warehouse Warehouse { get; set; }
        public User User { get; set; } // Assuming you have a navigation property to User

        public ICollection<InboundProductList> InboundProductLists { get; set; } = new List<InboundProductList>();
    }
}