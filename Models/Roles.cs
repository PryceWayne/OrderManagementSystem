using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class Roles
    {
        [Key]
        public string Role_ID { get; set; } // Primary Key

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Role_Description { get; set; }

        // Navigation Properties
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}