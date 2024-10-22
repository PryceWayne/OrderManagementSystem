using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class User
    {
        [Key]
        public string User_ID { get; set; } // Primary Key

        [Required]
        [StringLength(25)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; } // Passwords should be hashed

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        public DateTime Date_Created { get; set; }

        // Navigation Properties
        public ICollection<Billing> Billings { get; set; } = new List<Billing>();
        public ICollection<BillingAccount> BillingAccounts { get; set; } = new List<BillingAccount>();
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}