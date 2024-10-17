namespace OrderManagementSystem.Models
{
    public class Warehouse
    {
        public string Warehouse_ID { get; set; } // Primary Key
        public string Name { get; set; }         // Name of the warehouse
        public string Country { get; set; }      // Country where the warehouse is located
        public string City { get; set; }         // City where the warehouse is located
        public string Currency { get; set; }     // Currency used in the warehouse
    }
}