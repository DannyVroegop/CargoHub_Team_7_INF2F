using Microsoft.EntityFrameworkCore;
using Models;
namespace Data
{
    public class CargoContext: DbContext
    {
        public CargoContext(DbContextOptions<CargoContext> options)
            : base(options) { }

        // DbSets for each model
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<TransferItem> TransferItems { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentItem> ShipmentItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<ItemLine> ItemLines { get; set; }
        public DbSet<ItemGroup> ItemGroups { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Client> Clients { get; set; }

        // OnModelCreating to configure the relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasKey(i => i.Uid); // Set 'Uid' as the primary key for Item.

            // Configure composite key for OrderItem
            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.Order_Id, oi.Item_Uid }); // Composite key using Item_Uid.

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.Order_Id); // Foreign key to Order.

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Item)
                .WithMany() // Assuming no navigation property in Item for OrderItems.
                .HasForeignKey(oi => oi.Item_Uid)
                .HasPrincipalKey(i => i.Uid); // Map Item_Uid to Uid in Item.

            // Configure composite key for TransferItem
            modelBuilder.Entity<TransferItem>()
                .HasKey(ti => new { ti.Transfer_Id, ti.Item_Uid }); // Composite key using Item_Uid.

            modelBuilder.Entity<TransferItem>()
                .HasOne(ti => ti.Transfer)
                .WithMany(t => t.TransferItems)
                .HasForeignKey(ti => ti.Transfer_Id); // Foreign key to Transfer.

            modelBuilder.Entity<TransferItem>()
                .HasOne(ti => ti.Item)
                .WithMany() // Assuming no navigation property in Item for TransferItems.
                .HasForeignKey(ti => ti.Item_Uid)
                .HasPrincipalKey(i => i.Uid); // Map Item_Uid to Uid in Item.

            // Configure composite key for ShipmentItem
            modelBuilder.Entity<ShipmentItem>()
                .HasKey(si => new { si.Shipment_Id, si.Item_Uid }); // Composite key using Item_Uid.

            modelBuilder.Entity<ShipmentItem>()
                .HasOne(si => si.Shipment)
                .WithMany(s => s.ShipmentItems)
                .HasForeignKey(si => si.Shipment_Id); // Foreign key to Shipment.

            modelBuilder.Entity<ShipmentItem>()
                .HasOne(si => si.Item)
                .WithMany() // Assuming no navigation property in Item for ShipmentItems.
                .HasForeignKey(si => si.Item_Uid)
                .HasPrincipalKey(i => i.Uid); // Map Item_Uid to Uid in Item.

            // Additional configurations (if needed)...

            base.OnModelCreating(modelBuilder);
        }
    }
}
