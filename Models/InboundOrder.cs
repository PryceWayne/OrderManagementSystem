using System;
using System.Collections.Generic;

namespace OrderManagementSystem.Models
{
    public class InboundOrder
    {
        public string Inbound_Order_ID { get; set; }
        public string Order_Status { get; set; }
        public string Creator { get; set; }
        public string Warehouse_ID { get; set; }
        public DateTime Estimated_Arrival { get; set; }
        public int Product_Quantity { get; set; }
        public DateTime Creation_Date { get; set; }
        public double Cost { get; set; }
        public string Currency { get; set; }
        public int Boxes { get; set; }
        public string Inbound_Type { get; set; }
        public string Tracking_Number { get; set; }
        public string Reference_Order_Number { get; set; }
        public string Arrival_Method { get; set; }

        public Warehouse Warehouse { get; set; } // Navigation property

        // New property for related InboundProductLists
        public ICollection<InboundProductList> InboundProductLists { get; set; } // Collection of InboundProductLists
    }
}