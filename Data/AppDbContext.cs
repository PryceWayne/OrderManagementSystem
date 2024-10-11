using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Data
{
    public class AppDbContext : DbContext // Or ApplicationDbContext if that's what you named it
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } // DbSet for Users
        public DbSet<Order> Orders { get; set; } // DbSet for Orders

        // Optional: Add other DbSet properties for additional entities

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Optional: Customize the model creating if needed
            base.OnModelCreating(modelBuilder);
        }
    }
}