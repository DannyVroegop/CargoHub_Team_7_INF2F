using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NewWarehouse.Migrations
{
    /// <inheritdoc />
    public partial class innitial_build : Migration
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
                    Item_id = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Item_Reference = table.Column<string>(type: "text", nullable: false),
                    Total_On_Hand = table.Column<int>(type: "integer", nullable: false),
                    Total_Expected = table.Column<int>(type: "integer", nullable: false),
                    Total_Ordered = table.Column<int>(type: "integer", nullable: false),
                    Total_Allocated = table.Column<int>(type: "integer", nullable: false),
                    Total_Available = table.Column<int>(type: "integer", nullable: false),
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
                    Uid = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Short_Description = table.Column<string>(type: "text", nullable: false),
                    Upc_Code = table.Column<string>(type: "text", nullable: false),
                    Model_Number = table.Column<string>(type: "text", nullable: false),
                    Commodity_Code = table.Column<string>(type: "text", nullable: false),
                    Item_Line = table.Column<int>(type: "integer", nullable: false),
                    Item_Group = table.Column<int>(type: "integer", nullable: false),
                    Item_Type = table.Column<int>(type: "integer", nullable: false),
                    Unit_Purchase_Quantity = table.Column<int>(type: "integer", nullable: false),
                    Unit_Order_Quantity = table.Column<int>(type: "integer", nullable: false),
                    Pack_Order_Quantity = table.Column<int>(type: "integer", nullable: false),
                    Supplier_Id = table.Column<int>(type: "integer", nullable: false),
                    Supplier_Code = table.Column<string>(type: "text", nullable: false),
                    Supplier_Part_Number = table.Column<string>(type: "text", nullable: false),
                    Created_at = table.Column<string>(type: "text", nullable: false),
                    Updated_at = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Uid);
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
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Source_Id = table.Column<int>(type: "integer", nullable: false),
                    Order_Date = table.Column<string>(type: "text", nullable: false),
                    Request_date = table.Column<string>(type: "text", nullable: false),
                    Reference = table.Column<string>(type: "text", nullable: false),
                    Reference_Extra = table.Column<string>(type: "text", nullable: false),
                    Order_Status = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    Shipping_Notes = table.Column<string>(type: "text", nullable: false),
                    Picking_Notes = table.Column<string>(type: "text", nullable: false),
                    Warehouse_Id = table.Column<int>(type: "integer", nullable: false),
                    Ship_To = table.Column<int>(type: "integer", nullable: false),
                    Bill_To = table.Column<int>(type: "integer", nullable: false),
                    Shipment_Id = table.Column<int>(type: "integer", nullable: false),
                    Total_Ammount = table.Column<double>(type: "double precision", nullable: false),
                    Total_Discount = table.Column<double>(type: "double precision", nullable: false),
                    Total_Tax = table.Column<double>(type: "double precision", nullable: false),
                    Total_Surcharge = table.Column<double>(type: "double precision", nullable: false),
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
                    Order_Id = table.Column<int>(type: "integer", nullable: false),
                    Source_Id = table.Column<int>(type: "integer", nullable: false),
                    Order_Date = table.Column<string>(type: "text", nullable: false),
                    Request_date = table.Column<string>(type: "text", nullable: false),
                    Shipment_Date = table.Column<string>(type: "text", nullable: false),
                    Shipment_Type = table.Column<string>(type: "text", nullable: false),
                    Shipment_Status = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    Carrier_Code = table.Column<string>(type: "text", nullable: false),
                    Carrier_Description = table.Column<string>(type: "text", nullable: false),
                    Service_Code = table.Column<string>(type: "text", nullable: false),
                    Payment_Type = table.Column<string>(type: "text", nullable: false),
                    Transfer_Mode = table.Column<string>(type: "text", nullable: false),
                    Total_Package_Count = table.Column<int>(type: "integer", nullable: false),
                    Total_Package_Weight = table.Column<double>(type: "double precision", nullable: false),
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
                    Address_Extra = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: false),
                    Zip_Code = table.Column<string>(type: "text", nullable: false),
                    Province = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Contact_Name = table.Column<string>(type: "text", nullable: false),
                    Phonenumber = table.Column<string>(type: "text", nullable: false),
                    Reference = table.Column<string>(type: "text", nullable: false),
                    Created_at = table.Column<string>(type: "text", nullable: false),
                    Updated_at = table.Column<string>(type: "text", nullable: false)
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
                    Transfer_From = table.Column<string>(type: "text", nullable: false),
                    Transfer_To = table.Column<string>(type: "text", nullable: false),
                    Transfer_Status = table.Column<string>(type: "text", nullable: false),
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
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Warehouse_Id = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Created_at = table.Column<string>(type: "text", nullable: false),
                    Updated_at = table.Column<string>(type: "text", nullable: false),
                    InventoryId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Order_Id = table.Column<int>(type: "integer", nullable: false),
                    Item_Id = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => new { x.Order_Id, x.Item_Id });
                    table.ForeignKey(
                        name: "FK_OrderItem_Items_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "Items",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Orders_Order_Id",
                        column: x => x.Order_Id,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentItems",
                columns: table => new
                {
                    Shipment_Id = table.Column<int>(type: "integer", nullable: false),
                    Item_Id = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentItems", x => new { x.Shipment_Id, x.Item_Id });
                    table.ForeignKey(
                        name: "FK_ShipmentItems_Items_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "Items",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShipmentItems_Shipments_Shipment_Id",
                        column: x => x.Shipment_Id,
                        principalTable: "Shipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransferItems",
                columns: table => new
                {
                    Transfer_Id = table.Column<int>(type: "integer", nullable: false),
                    Item_Id = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferItems", x => new { x.Transfer_Id, x.Item_Id });
                    table.ForeignKey(
                        name: "FK_TransferItems_Items_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "Items",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransferItems_Transfers_Transfer_Id",
                        column: x => x.Transfer_Id,
                        principalTable: "Transfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_InventoryId",
                table: "Locations",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_Item_Id",
                table: "OrderItem",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentItems_Item_Id",
                table: "ShipmentItems",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TransferItems_Item_Id",
                table: "TransferItems",
                column: "Item_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

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
                name: "Inventories");

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
