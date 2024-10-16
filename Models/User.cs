using System;

namespace OrderManagementSystem.Models
{
    public class User
    {
        public string User_ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime Date_Created { get; set; }
    }
}