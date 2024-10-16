namespace OrderManagementSystem.Models
{
    public class Inventory
    {
        public string Product_ID { get; set; }
        public string Warehouse_ID { get; set; }
        public string SKU { get; set; }
        public string Product_Name { get; set; }
        public string Product_Description { get; set; }

        public Warehouse Warehouse { get; set; } // Navigation property
    }
}
