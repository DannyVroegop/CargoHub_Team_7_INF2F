using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NewWarehouse.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Zip_Code = table.Column<string>(type: "text", nullable: false),
                    Province = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Contact_Name = table.Column<string>(type: "text", nullable: false),
                    Contact_Phone = table.Column<string>(type: "text", nullable: false),
                    Contact_Email = table.Column<string>(type: "text", nullable: false),
                    Created_at = table.Column<string>(type: "text", nullable: false),
                    Updated_at = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Item_id = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ItemReference = table.Column<string>(type: "text", nullable: false),
                    Location_Id = table.Column<string>(type: "text", nullable: false),
                    TotalOnHand = table.Column<int>(type: "integer", nullable: false),
                    TotalExpected = table.Column<int>(type: "integer", nullable: false),
                    TotalOrdered = table.Column<int>(type: "integer", nullable: false),
                    TotalAllocated = table.Column<int>(type: "integer", nullable: false),
                    TotalAvailable = table.Column<int>(type: "integer", nullable: false),
                    Created_at = table.Column<string>(type: "text", nullable: false),
                    Updated_at = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Created_at = table.Column<string>(type: "text", nullable: false),
                    Updated_at = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Created_at = table.Column<string>(type: "text", nullable: false),
                    Updated_at = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemLines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ShortDescription = table.Column<string>(type: "text", nullable: false),
                    UpcCode = table.Column<string>(type: "text", nullable: false),
                    ModelNumber = table.Column<string>(type: "text", nullable: false),
                    CommodityCode = table.Column<string>(type: "text", nullable: false),
                    ItemLineId = table.Column<int>(type: "integer", nullable: false),
                    ItemGroupId = table.Column<int>(type: "integer", nullable: false),
                    ItemTypeId = table.Column<int>(type: "integer", nullable: false),
                    UnitPurchaseQuantity = table.Column<int>(type: "integer", nullable: false),
                    UnitOrderQuantity = table.Column<int>(type: "integer", nullable: false),
                    PackOrderQuantity = table.Column<int>(type: "integer", nullable: false),
                    SupplierId = table.Column<int>(type: "integer", nullable: false),
                    SupplierCode = table.Column<string>(type: "text", nullable: false),
                    SupplierPartNumber = table.Column<string>(type: "text", nullable: false),
                    Created_at = table.Column<string>(type: "text", nullable: false),
                    Updated_at = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Created_at = table.Column<string>(type: "text", nullable: false),
                    Updated_at = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WarehouseId = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Created_at = table.Column<string>(type: "text", nullable: false),
                    Updated_at = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SourceId = table.Column<int>(type: "integer", nullable: false),
                    OrderDate = table.Column<string>(type: "text", nullable: false),
                    Requestdate = table.Column<string>(type: "text", nullable: false),
                    Reference = table.Column<string>(type: "text", nullable: false),
                    ReferenceExtra = table.Column<string>(type: "text", nullable: false),
                    OrderStatus = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    ShippingNotes = table.Column<string>(type: "text", nullable: false),
                    PickingNotes = table.Column<string>(type: "text", nullable: false),
                    WarehouseId = table.Column<int>(type: "integer", nullable: false),
                    ShipTo = table.Column<int>(type: "integer", nullable: false),
                    BillTo = table.Column<int>(type: "integer", nullable: false),
                    ShipmentId = table.Column<int>(type: "integer", nullable: false),
                    TotalAmmount = table.Column<double>(type: "double precision", nullable: false),
                    TotalDiscount = table.Column<double>(type: "double precision", nullable: false),
                    TotalTax = table.Column<double>(type: "double precision", nullable: false),
                    TotalSurcharge = table.Column<double>(type: "double precision", nullable: false),
                    Created_at = table.Column<string>(type: "text", nullable: false),
                    Updated_at = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    SourceId = table.Column<int>(type: "integer", nullable: false),
                    OrderDate = table.Column<string>(type: "text", nullable: false),
                    Requestdate = table.Column<string>(type: "text", nullable: false),
                    ShipmentDate = table.Column<string>(type: "text", nullable: false),
                    ShipmentType = table.Column<string>(type: "text", nullable: false),
                    ShipmentStatus = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    CarrierCode = table.Column<string>(type: "text", nullable: false),
                    CarrierDescription = table.Column<string>(type: "text", nullable: false),
                    ServiceCode = table.Column<string>(type: "text", nullable: false),
                    PaymentType = table.Column<string>(type: "text", nullable: false),
                    TransferMode = table.Column<string>(type: "text", nullable: false),
                    TotalPackageCount = table.Column<int>(type: "integer", nullable: false),
                    TotalPackageWeight = table.Column<double>(type: "double precision", nullable: false),
                    Created_at = table.Column<string>(type: "text", nullable: false),
                    Updated_at = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Zip_Code = table.Column<string>(type: "text", nullable: false),
                    Province = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    ContactName = table.Column<string>(type: "text", nullable: false),
                    ContactPhone = table.Column<string>(type: "text", nullable: false),
                    Reference = table.Column<string>(type: "text", nullable: false),
                    Created_at = table.Column<string>(type: "text", nullable: false),
                    Updated_at = table.Column<string>(type: "text", nullable: false),
                    AddressExtra = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Reference = table.Column<string>(type: "text", nullable: false),
                    TransferFrom = table.Column<string>(type: "text", nullable: false),
                    TransferTo = table.Column<string>(type: "text", nullable: false),
                    TransferStatus = table.Column<string>(type: "text", nullable: false),
                    Created_at = table.Column<string>(type: "text", nullable: false),
                    Updated_at = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Zip_Code = table.Column<string>(type: "text", nullable: false),
                    Province = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    ContactName = table.Column<string>(type: "text", nullable: false),
                    ContactPhone = table.Column<string>(type: "text", nullable: false),
                    ContactEmail = table.Column<string>(type: "text", nullable: false),
                    Created_at = table.Column<string>(type: "text", nullable: false),
                    Updated_at = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => new { x.OrderId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_OrderItem_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentItems",
                columns: table => new
                {
                    ShipmentId = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentItems", x => new { x.ShipmentId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_ShipmentItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShipmentItems_Shipments_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransferItems",
                columns: table => new
                {
                    TransferId = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferItems", x => new { x.TransferId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_TransferItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransferItems_Transfers_TransferId",
                        column: x => x.TransferId,
                        principalTable: "Transfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ItemId",
                table: "OrderItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentItems_ItemId",
                table: "ShipmentItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferItems_ItemId",
                table: "TransferItems",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "ItemGroups");

            migrationBuilder.DropTable(
                name: "ItemLines");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "ShipmentItems");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "TransferItems");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Shipments");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Transfers");
        }
    }
}
