using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // User and Role Management
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; } // Assuming UserRole is defined

        // Billing Tables
        public DbSet<BillingAccount> BillingAccounts { get; set; }
        public DbSet<CostBasedCharge> CostBasedCharges { get; set; }
        public DbSet<OrderBasedCharge> OrderBasedCharges { get; set; }
        public DbSet<CostBasedBilling> CostBasedBillings { get; set; }
        public DbSet<OrderBasedBilling> OrderBasedBillings { get; set; }

        // Warehouse and Inventory Management
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        // Orders
        public DbSet<InboundOrder> InboundOrders { get; set; }
        public DbSet<FreightOutbound> FreightOutbounds { get; set; }
        public DbSet<ParcelOutbound> ParcelOutbounds { get; set; }

        // Product Lists
        public DbSet<InboundProductList> InboundProductLists { get; set; }
        public DbSet<FreightProductList> FreightProductLists { get; set; }
        public DbSet<ParcelProductList> ParcelProductLists { get; set; }

        public DbSet<PlatformOrder> PlatformOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite keys for UserRole
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.User_ID, ur.Role_ID });

            // Configure any additional relationships if necessary
        }
    }
}