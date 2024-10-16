namespace OrderManagementSystem.Models
{
    public class FreightOutbound
    {
        public string Outbound_Order_ID { get; set; }
        public string Order_Type { get; set; }
        public string Order_Status { get; set; }
        public string Creator { get; set; }
        public string Warehouse_ID { get; set; }
        public int Product_Quantity { get; set; }
        public DateTime Creation_Date { get; set; }
        public DateTime Estimated_Delivery_Date { get; set; }
        public DateTime Order_Ship_Date { get; set; }
        public double Cost { get; set; }
        public string Currency { get; set; }
        public string Recipient { get; set; }
        public string Recipient_Post_Code { get; set; }
        public string Destination_Type { get; set; }
        public string Platform { get; set; }
        public string Shipping_Company { get; set; }
        public int Transport_Days { get; set; }
        public string Related_Adjustment_Order { get; set; }
        public string Tracking_Number { get; set; }
        public string Reference_Order_Number { get; set; }
        public string FBA_Shipment_ID { get; set; }
        public string FBA_Tracking_Number { get; set; }
        public string Outbound_Method { get; set; }

        public Warehouse Warehouse { get; set; } // Navigation property
    }
}
