using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace OrderManagementSystem.Models
{
    public class UserRole
    {
        public string User_ID { get; set; } // Foreign Key to User
        public string Role_ID { get; set; } // Foreign Key to Role

        // Navigation properties
        public User User { get; set; }
        public Roles Role { get; set; }
    }
}