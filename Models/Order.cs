using System;

namespace OrderManagementSystem.Models
{
    public class Order
    {
        public string OrderId { get; set; }  // Unique identifier for the order
        public string UserId { get; set; }   // Foreign key reference to User
        public DateTime OrderDate { get; set; } // Date the order was created
        public decimal TotalAmount { get; set; } // Total cost of the order

        // Optional: Navigation property for the related user
        public User User { get; set; }
    }
}