using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class Role
    {
        [Key]
        public string RoleId { get; set; } 

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [StringLength(255)]
        public string RoleDescription { get; set; } 

        // Navigation Properties
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}