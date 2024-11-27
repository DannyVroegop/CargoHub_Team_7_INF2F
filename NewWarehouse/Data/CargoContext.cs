using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class CargoContext : DbContext
    {
        public CargoContext(DbContextOptions<CargoContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemGroup> ItemGroups { get; set; }
        public DbSet<ItemLine> ItemLines { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<ShipmentItem> ShipmentItems { get; set; }
        public DbSet<TransferItem> TransferItems { get; set; }

                protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring many-to-many relationships
            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.ItemId });
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Item)
                .WithMany(i => i.OrderItems)
                .HasForeignKey(oi => oi.ItemId);

            modelBuilder.Entity<ShipmentItem>()
                .HasKey(si => new { si.ShipmentId, si.ItemId });
            modelBuilder.Entity<ShipmentItem>()
                .HasOne(si => si.Shipment)
                .WithMany(s => s.ShipmentItems)
                .HasForeignKey(si => si.ShipmentId);
            modelBuilder.Entity<ShipmentItem>()
                .HasOne(si => si.Item)
                .WithMany(i => i.ShipmentItems)
                .HasForeignKey(si => si.ItemId);

            modelBuilder.Entity<TransferItem>()
                .HasKey(ti => new { ti.TransferId, ti.ItemId });
            modelBuilder.Entity<TransferItem>()
                .HasOne(ti => ti.Transfer)
                .WithMany(t => t.TransferItems)
                .HasForeignKey(ti => ti.TransferId);
            modelBuilder.Entity<TransferItem>()
                .HasOne(ti => ti.Item)
                .WithMany(i => i.TransferItems)
                .HasForeignKey(ti => ti.ItemId);
        }
    }
}
