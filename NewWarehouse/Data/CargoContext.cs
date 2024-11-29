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
            .HasKey(i => i.Uid); // This sets 'Uid' as the primary key for Item.

            // Configure one-to-many relationships

            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.Order_Id, oi.Item_Id });  // Composite key

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.Order_Id);


            modelBuilder.Entity<TransferItem>()
                .HasKey(oi => new { oi.Transfer_Id, oi.Item_Id });  // Composite key
            
            modelBuilder.Entity<TransferItem>()
                .HasOne(ti => ti.Transfer)
                .WithMany(t => t.TransferItems)
                .HasForeignKey(ti => ti.Transfer_Id);


            modelBuilder.Entity<ShipmentItem>()
                .HasKey(oi => new { oi.Shipment_Id, oi.Item_Id });  // Composite key            

            modelBuilder.Entity<ShipmentItem>()
                .HasOne(si => si.Shipment)
                .WithMany(s => s.ShipmentItems)
                .HasForeignKey(si => si.Shipment_Id);

            // Additional configurations can be added here (e.g., for composite keys, relationships, etc.)

            base.OnModelCreating(modelBuilder);
        }
    }
}
