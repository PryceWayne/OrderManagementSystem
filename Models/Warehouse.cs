namespace OrderManagementSystem.Models
{
    public class Warehouse
    {
        public string Warehouse_ID { get; set; } // Renamed from 'Warehouse' to 'Warehouse_ID'
        public string Name { get; set; }         // Changed 'Warehouse' to 'Name'
        public string Country { get; set; }
        public string City { get; set; }
        public string Currency { get; set; }
    }
}