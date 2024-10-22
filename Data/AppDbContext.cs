using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Models;
using System.Data;

namespace OrderManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        // Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSet properties for all entities
        // User and Role Management
        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        // Billing Tables
        public DbSet<BillingAccount> BillingAccounts { get; set; }
        public DbSet<Billing> Billings { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Cost_Based_Charges> Cost_Based_Charges { get; set; }
        public DbSet<Order_Based_Charges> Order_Based_Charges { get; set; }
        public DbSet<Cost_Based_Billing> Cost_Based_Billings { get; set; }
        public DbSet<Order_Based_Billing> Order_Based_Billings { get; set; }

        // Warehouse and Inventory Management
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        // Orders
        public DbSet<InboundOrders> InboundOrders { get; set; }
        public DbSet<FreightOutbound> FreightOutbounds { get; set; }
        public DbSet<ParcelOutbound> ParcelOutbounds { get; set; }

        // Product Lists
        public DbSet<InboundProductList> InboundProductLists { get; set; }
        public DbSet<FreightProductList> FreightProductLists { get; set; }
        public DbSet<ParcelProductList> ParcelProductLists { get; set; }

        // Platform Orders
        public DbSet<PlatformOrder> PlatformOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User Entity Configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.User_ID);

                entity.Property(u => u.User_ID)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(u => u.Username)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(u => u.Password)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(u => u.Date_Created)
                    .IsRequired();

                // Relationships
                entity.HasMany(u => u.UserRoles)
                    .WithOne(ur => ur.User)
                    .HasForeignKey(ur => ur.User_ID)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(u => u.BillingAccounts)
                    .WithOne(ba => ba.User)
                    .HasForeignKey(ba => ba.User_ID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Role Entity Configuration
            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(r => r.Role_ID);

                entity.Property(r => r.Role_ID)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(r => r.Name)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(r => r.Role_Description)
                    .HasMaxLength(255);

                // Relationships
                entity.HasMany(r => r.UserRoles)
                    .WithOne(ur => ur.Role)
                    .HasForeignKey(ur => ur.Role_ID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // UserRole Entity Configuration (Composite Key)
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(ur => new { ur.User_ID, ur.Role_ID });

                // Relationships configured in User and Role entities
            });

            // BillingAccount Entity Configuration
            modelBuilder.Entity<BillingAccount>(entity =>
            {
                entity.HasKey(ba => ba.Billing_Account_ID);

                entity.Property(ba => ba.Billing_Account_ID)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(ba => ba.User_ID)
                    .IsRequired()
                    .HasMaxLength(25);

                // Relationships
                entity.HasOne(ba => ba.User)
                    .WithMany(u => u.BillingAccounts)
                    .HasForeignKey(ba => ba.User_ID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(ba => ba.Billings)
                    .WithOne(b => b.BillingAccount)
                    .HasForeignKey(b => b.Billing_Account_ID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Billing Entity Configuration
            modelBuilder.Entity<Billing>(entity =>
            {
                entity.HasKey(b => b.Billing_ID);

                entity.Property(b => b.Billing_ID)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(b => b.Billing_Account_ID)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(b => b.Amount)
                    .IsRequired();

                entity.Property(b => b.DateCreated)
                    .IsRequired();

                // Relationships
                entity.HasOne(b => b.BillingAccount)
                    .WithMany(ba => ba.Billings)
                    .HasForeignKey(b => b.Billing_Account_ID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Cost Entity Configuration
            modelBuilder.Entity<Cost>(entity =>
            {
                entity.HasKey(c => c.Cost_ID);

                entity.Property(c => c.Cost_ID)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(c => c.Amount)
                    .IsRequired();

                entity.Property(c => c.Description)
                    .HasMaxLength(255);
            });

            // Cost_Based_Charges Entity Configuration
            modelBuilder.Entity<Cost_Based_Charges>(entity =>
            {
                entity.HasKey(cbc => cbc.Cost_Charge_ID);

                entity.Property(cbc => cbc.Cost_Charge_ID)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(cbc => cbc.Amount);

                entity.Property(cbc => cbc.Description)
                    .HasMaxLength(255);
            });

            // Cost_Based_Billing Entity Configuration (Composite Key)
            modelBuilder.Entity<Cost_Based_Billing>(entity =>
            {
                entity.HasKey(cbb => new { cbb.Billing_Account_ID, cbb.Cost_Charge_ID });

                entity.Property(cbb => cbb.Billing_Account_ID)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(cbb => cbb.Cost_Charge_ID)
                    .IsRequired()
                    .HasMaxLength(25);

                // Relationships
                entity.HasOne(cbb => cbb.BillingAccount)
                    .WithMany(ba => ba.Cost_Based_Billings)
                    .HasForeignKey(cbb => cbb.Billing_Account_ID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(cbb => cbb.Cost_Based_Charges)
                    .WithMany()
                    .HasForeignKey(cbb => cbb.Cost_Charge_ID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Order_Based_Charges Entity Configuration
            modelBuilder.Entity<Order_Based_Charges>(entity =>
            {
                entity.HasKey(obc => obc.Order_Charge_ID);

                entity.Property(obc => obc.Order_Charge_ID)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(obc => obc.Amount);

                entity.Property(obc => obc.Description)
                    .HasMaxLength(255);
            });

            // Order_Based_Billing Entity Configuration (Composite Key)
            modelBuilder.Entity<Order_Based_Billing>(entity =>
            {
                entity.HasKey(obb => new { obb.Billing_Account_ID, obb.Order_Charge_ID });

                entity.Property(obb => obb.Billing_Account_ID)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(obb => obb.Order_Charge_ID)
                    .IsRequired()
                    .HasMaxLength(25);

                // Relationships
                entity.HasOne(obb => obb.BillingAccount)
                    .WithMany(ba => ba.Order_Based_Billings)
                    .HasForeignKey(obb => obb.Billing_Account_ID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(obb => obb.Order_Based_Charges)
                    .WithMany()
                    .HasForeignKey(obb => obb.Order_Charge_ID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Warehouse Entity Configuration
            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasKey(w => w.Warehouse_ID);

                entity.Property(w => w.Warehouse_ID)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(w => w.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(w => w.Country)
                    .HasMaxLength(50);

                entity.Property(w => w.City)
                    .HasMaxLength(50);

                entity.Property(w => w.Currency)
                    .HasMaxLength(50);

                // Relationships
                entity.HasMany(w => w.Inventories)
                    .WithOne(i => i.Warehouse)
                    .HasForeignKey(i => i.Warehouse_ID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(w => w.InboundOrders)
                    .WithOne(io => io.Warehouse)
                    .HasForeignKey(io => io.Warehouse_ID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(w => w.FreightOutbounds)
                    .WithOne(fo => fo.Warehouse)
                    .HasForeignKey(fo => fo.Warehouse_ID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(w => w.ParcelOutbounds)
                    .WithOne(po => po.Warehouse)
                    .HasForeignKey(po => po.Warehouse_ID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Inventory Entity Configuration
            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(i => i.Product_ID);

                entity.Property(i => i.Product_ID)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(i => i.Warehouse_ID)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(i => i.SKU)
                    .HasMaxLength(50);

                entity.Property(i => i.Product_Name)
                    .HasMaxLength(255);

                entity.Property(i => i.Product_Description)
                    .HasMaxLength(255);

                // Relationships
                entity.HasOne(i => i.Warehouse)
                    .WithMany(w => w.Inventories)
                    .HasForeignKey(i => i.Warehouse_ID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(i => i.InboundProductLists)
                    .WithOne(ipl => ipl.Inventory)
                    .HasForeignKey(ipl => ipl.Product_ID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(i => i.FreightProductLists)
                    .WithOne(fpl => fpl.Inventory)
                    .HasForeignKey(fpl => fpl.Product_ID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(i => i.ParcelProductLists)
                    .WithOne(ppl => ppl.Inventory)
                    .HasForeignKey(ppl => ppl.Product_ID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // InboundOrders Entity Configuration
            modelBuilder.Entity<InboundOrders>(entity =>
            {
                entity.HasKey(io => io.Inbound_Order_ID);

                entity.Property(io => io.Inbound_Order_ID)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(io => io.Order_Status)
                    .HasMaxLength(25);

                entity.Property(io => io.Creator)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(io => io.Warehouse_ID)
                    .IsRequired()
                    .HasMaxLength(25);

                // Relationships
                entity.HasOne(io => io.Warehouse)
                    .WithMany(w => w.InboundOrders)
                    .HasForeignKey(io => io.Warehouse_ID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(io => io.User)
                    .WithMany()
                    .HasForeignKey(io => io.Creator)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(io => io.InboundProductLists)
                    .WithOne(ipl => ipl.InboundOrder)
                    .HasForeignKey(ipl => ipl.Order_ID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // InboundProductList Entity Configuration (Composite Key)
            modelBuilder.Entity<InboundProductList>(entity =>
            {
                entity.HasKey(ipl => new { ipl.Order_ID, ipl.Product_ID });

                // Relationships
                entity.HasOne(ipl => ipl.InboundOrder)
                    .WithMany(io => io.InboundProductLists)
                    .HasForeignKey(ipl => ipl.Order_ID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ipl => ipl.Inventory)
                    .WithMany(i => i.InboundProductLists)
                    .HasForeignKey(ipl => ipl.Product_ID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // FreightOutbound Entity Configuration
            modelBuilder.Entity<FreightOutbound>(entity =>
            {
                entity.HasKey(fo => fo.Outbound_Order_ID);

                entity.Property(fo => fo.Outbound_Order_ID)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(fo => fo.Order_Type)
                    .HasMaxLength(25);

                entity.Property(fo => fo.Order_Status)
                    .HasMaxLength(25);

                entity.Property(fo => fo.Creator)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(fo => fo.Warehouse_ID)
                    .IsRequired()
                    .HasMaxLength(25);

                // Relationships
                entity.HasOne(fo => fo.Warehouse)
                    .WithMany(w => w.FreightOutbounds)
                    .HasForeignKey(fo => fo.Warehouse_ID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(fo => fo.User)
                    .WithMany()
                    .HasForeignKey(fo => fo.Creator)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(fo => fo.FreightProductLists)
                    .WithOne(fpl => fpl.FreightOutbound)
                    .HasForeignKey(fpl => fpl.Order_ID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // FreightProductList Entity Configuration (Composite Key)
            modelBuilder.Entity<FreightProductList>(entity =>
            {
                entity.HasKey(fpl => new { fpl.Order_ID, fpl.Product_ID });

                // Relationships
                entity.HasOne(fpl => fpl.FreightOutbound)
                    .WithMany(fo => fo.FreightProductLists)
                    .HasForeignKey(fpl => fpl.Order_ID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(fpl => fpl.Inventory)
                    .WithMany(i => i.FreightProductLists)
                    .HasForeignKey(fpl => fpl.Product_ID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ParcelOutbound Entity Configuration
            modelBuilder.Entity<ParcelOutbound>(entity =>
            {
                entity.HasKey(po => po.Order_ID);

                entity.Property(po => po.Order_ID)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(po => po.Order_Type)
                    .HasMaxLength(25);

                entity.Property(po => po.Order_Status)
                    .HasMaxLength(25);

                entity.Property(po => po.Warehouse_ID)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(po => po.Creator)
                    .IsRequired()
                    .HasMaxLength(25);

                // Relationships
                entity.HasOne(po => po.Warehouse)
                    .WithMany(w => w.ParcelOutbounds)
                    .HasForeignKey(po => po.Warehouse_ID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(po => po.User)
                    .WithMany()
                    .HasForeignKey(po => po.Creator)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(po => po.ParcelProductLists)
                    .WithOne(ppl => ppl.ParcelOutbound)
                    .HasForeignKey(ppl => ppl.Order_ID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ParcelProductList Entity Configuration (Composite Key)
            modelBuilder.Entity<ParcelProductList>(entity =>
            {
                entity.HasKey(ppl => new { ppl.Order_ID, ppl.Product_ID });

                // Relationships
                entity.HasOne(ppl => ppl.ParcelOutbound)
                    .WithMany(po => po.ParcelProductLists)
                    .HasForeignKey(ppl => ppl.Order_ID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ppl => ppl.Inventory)
                    .WithMany(i => i.ParcelProductLists)
                    .HasForeignKey(ppl => ppl.Product_ID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // PlatformOrder Entity Configuration
            modelBuilder.Entity<PlatformOrder>(entity =>
            {
                entity.HasKey(po => po.Order_ID);

                entity.Property(po => po.Order_ID)
                    .IsRequired()
                    .HasMaxLength(25);

                
            });

            
        }
    }
}