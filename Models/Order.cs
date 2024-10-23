using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class Order
    {
        [Key]
        [StringLength(25)]
        public string OrderId { get; set; }

        [Required]
        [StringLength(25)]
        public string CustomerId { get; set; }

        [Required]
        [StringLength(25)]
        public string UserId { get; set; } 

        [Required]
        public DateTime OrderDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        [StringLength(25)]
        public string OrderStatus { get; set; }

        public double TotalAmount { get; set; }

        // Navigation Properties
        public User User { get; set; } 
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}