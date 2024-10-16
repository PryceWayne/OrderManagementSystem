namespace OrderManagementSystem.Models
{
    public class UserRole
    {
        public string User_ID { get; set; }
        public string Role_ID { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Role Role { get; set; }
    }
}