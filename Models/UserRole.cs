using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class UserRole
    {
        [Required]
        public string UserId { get; set; } 

        [Required]
        public string RoleId { get; set; } 

       
        public User User { get; set; }
        public Role Role { get; set; }
    }
}