using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class PlatformOrder
    {
        [Key]
        public string Order_ID { get; set; } // Primary Key

        // Add additional properties as necessary
    }
}