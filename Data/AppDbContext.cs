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
        public DbSet<UserRole> UserRoles { get; set; }

        // Billing Tables 
        public DbSet<BillingAccount> BillingAccounts { get; set; }
        public DbSet<Billing> Billings { get; set; }
        public DbSet<Cost> Costs { get; set; }

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
            // Configure User entity
            modelBuilder.Entity<User>()
                .HasKey(u => u.User_ID); // Set User_ID as primary key

            // Composite keys for UserRole
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.User_ID, ur.Role_ID });

            // Configure the Billing entity
            modelBuilder.Entity<Billing>()
                .HasKey(b => b.Billing_ID); // Set Billing_ID as primary key

            modelBuilder.Entity<Billing>()
                .HasOne(b => b.BillingAccount) // Relationship to BillingAccount
                .WithMany(ba => ba.Billings)    // One BillingAccount can have many Billings
                .HasForeignKey(b => b.Billing_Account_ID); // Foreign key relationship

            // Configure BillingAccount entity
            modelBuilder.Entity<BillingAccount>()
                .HasKey(ba => ba.Billing_Account_ID); // Set Billing_Account_ID as primary key

            modelBuilder.Entity<BillingAccount>()
                .HasOne(ba => ba.User) // Relationship to User
                .WithMany(u => u.BillingAccounts) // One User can have many BillingAccounts
                .HasForeignKey(ba => ba.User_ID); // Foreign key relationship

            // Configure Costs entity
            modelBuilder.Entity<Cost>()
                .HasKey(c => c.Cost_ID); // Set Cost_ID as primary key

            // Configure Inventory entity
            modelBuilder.Entity<Inventory>()
                .HasKey(i => i.Product_ID); // Set Product_ID as primary key

            modelBuilder.Entity<Inventory>()
                .HasOne(i => i.Warehouse) // Relationship to Warehouse
                .WithMany() // Assuming one Warehouse can have many Inventory items
                .HasForeignKey(i => i.Warehouse_ID); // Foreign key relationship

            // Configure Warehouse entity
            modelBuilder.Entity<Warehouse>()
                .HasKey(w => w.Warehouse_ID); // Set Warehouse_ID as primary key

            // Configure InboundOrder entity
            modelBuilder.Entity<InboundOrder>()
                .HasKey(io => io.Inbound_Order_ID); // Set Inbound_Order_ID as primary key

            modelBuilder.Entity<InboundOrder>()
                .HasOne(io => io.Warehouse) // Relationship to Warehouse
                .WithMany() // Assuming one Warehouse can have many InboundOrders
                .HasForeignKey(io => io.Warehouse_ID); // Foreign key relationship

            // Configure FreightOutbound entity
            modelBuilder.Entity<FreightOutbound>()
                .HasKey(fo => fo.Outbound_Order_ID); // Set Outbound_Order_ID as primary key

            modelBuilder.Entity<FreightOutbound>()
                .HasOne(fo => fo.Warehouse) // Relationship to Warehouse
                .WithMany() // Assuming one Warehouse can have many FreightOutbounds
                .HasForeignKey(fo => fo.Warehouse_ID); // Foreign key relationship

            // Configure ParcelOutbound entity
            modelBuilder.Entity<ParcelOutbound>()
                .HasKey(po => po.Order_ID); // Set Order_ID as primary key

            modelBuilder.Entity<ParcelOutbound>()
                .HasOne(po => po.Warehouse) // Relationship to Warehouse
                .WithMany() // Assuming one Warehouse can have many ParcelOutbounds
                .HasForeignKey(po => po.Warehouse_ID); // Foreign key relationship

            // Configure FreightProductList entity
            modelBuilder.Entity<FreightProductList>()
                .HasKey(fpl => new { fpl.Order_ID, fpl.Product_ID }); // Set composite key

            // Configure InboundProductList entity
            modelBuilder.Entity<InboundProductList>()
                .HasKey(ip => new { ip.Order_ID, ip.Product_ID }); // Set composite key

            modelBuilder.Entity<InboundProductList>()
                .HasOne(ip => ip.InboundOrder) // Relationship to InboundOrder
                .WithMany(io => io.InboundProductLists) // Assuming InboundOrder has a collection of InboundProductLists
                .HasForeignKey(ip => ip.Order_ID); // Foreign key relationship

            modelBuilder.Entity<InboundProductList>()
                .HasOne(ip => ip.Inventory) // Relationship to Inventory
                .WithMany() // Assuming Inventory can be referenced by multiple InboundProductLists
                .HasForeignKey(ip => ip.Product_ID); // Foreign key relationship

            // Configure ParcelProductList entity
            modelBuilder.Entity<ParcelProductList>()
                .HasKey(ppl => new { ppl.Order_ID, ppl.Product_ID }); // Set composite key

            modelBuilder.Entity<ParcelProductList>()
                .HasOne(ppl => ppl.ParcelOutbound) // Relationship to ParcelOutbound
                .WithMany(po => po.ParcelProductLists) // Assuming ParcelOutbound has a collection of ParcelProductLists
                .HasForeignKey(ppl => ppl.Order_ID); // Foreign key relationship

            modelBuilder.Entity<ParcelProductList>()
                .HasOne(ppl => ppl.Inventory) // Relationship to Inventory
                .WithMany() // Assuming Inventory can be referenced by multiple ParcelProductLists
                .HasForeignKey(ppl => ppl.Product_ID); // Foreign key relationship

            // Configure PlatformOrder entity
            modelBuilder.Entity<PlatformOrder>()
                .HasKey(po => po.Order_ID); // Set Order_ID as primary key

            // Configure Role entity
            modelBuilder.Entity<Role>()
                .HasKey(r => r.Role_ID); // Set Role_ID as primary key
        }
    }
}