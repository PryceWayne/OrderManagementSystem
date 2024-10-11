using System;

namespace OrderManagementSystem.Models
{
    public class User
    {
        public string UserId { get; set; }  // Unique identifier for the user
        public string Username { get; set; } // Username for the user
        public string Password { get; set; } // Password for the user
        public string Email { get; set; } // User's email address
        public DateTime DateCreated { get; set; } // Account creation date
    }
}