namespace OrderManagementSystem.Models
{
    public class ParcelOutbound
    {

        public string Order_ID { get; set; }
        public string Order_Type { get; set; }
        public string Order_Status { get; set; }
        public string Warehouse_ID { get; set; }
        public string Creator { get; set; }
        public string Platform { get; set; }
        public DateTime Estimated_Delivery_Date { get; set; }
        public DateTime Ship_Date { get; set; }
        public int Transport_Days { get; set; }
        public double Cost { get; set; }
        public string Currency { get; set; }
        public string Recipient { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
        public string Tracking_Number { get; set; }
        public string Reference_Order_Number { get; set; }
        public DateTime Creation_Date { get; set; }
        public int Boxes { get; set; }
        public string Shipping_Company { get; set; }
        public string Latest_Information { get; set; }
        public DateTime Tracking_Update_Time { get; set; }
        public DateTime Internet_Posting_Time { get; set; }
        public DateTime Delivery_Time { get; set; }
        public string Related_Adjustment_Order { get; set; }

        public Warehouse Warehouse { get; set; } // Navigation property
    }
}

