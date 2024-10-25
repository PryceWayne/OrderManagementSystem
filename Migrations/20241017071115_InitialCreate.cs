using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagementSystem.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Costs",
                columns: table => new
                {
                    Cost_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costs", x => x.Cost_ID);
                });

            migrationBuilder.CreateTable(
                name: "PlatformOrders",
                columns: table => new
                {
                    Order_ID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformOrders", x => x.Order_ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Role_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role_Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Role_ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_ID);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Warehouse_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Warehouse_ID);
                });

            migrationBuilder.CreateTable(
                name: "BillingAccounts",
                columns: table => new
                {
                    Billing_Account_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    User_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Account_Balance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingAccounts", x => x.Billing_Account_ID);
                    table.ForeignKey(
                        name: "FK_BillingAccounts_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    User_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Role_ID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.User_ID, x.Role_ID });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_Role_ID",
                        column: x => x.Role_ID,
                        principalTable: "Roles",
                        principalColumn: "Role_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FreightOutbounds",
                columns: table => new
                {
                    Outbound_Order_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Order_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Warehouse_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Product_Quantity = table.Column<int>(type: "int", nullable: false),
                    Creation_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estimated_Delivery_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Order_Ship_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recipient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recipient_Post_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shipping_Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transport_Days = table.Column<int>(type: "int", nullable: false),
                    Related_Adjustment_Order = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tracking_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference_Order_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FBA_Shipment_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FBA_Tracking_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Outbound_Method = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreightOutbounds", x => x.Outbound_Order_ID);
                    table.ForeignKey(
                        name: "FK_FreightOutbounds_Warehouses_Warehouse_ID",
                        column: x => x.Warehouse_ID,
                        principalTable: "Warehouses",
                        principalColumn: "Warehouse_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InboundOrders",
                columns: table => new
                {
                    Inbound_Order_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Order_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Warehouse_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Estimated_Arrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Product_Quantity = table.Column<int>(type: "int", nullable: false),
                    Creation_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Boxes = table.Column<int>(type: "int", nullable: false),
                    Inbound_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tracking_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference_Order_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arrival_Method = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InboundOrders", x => x.Inbound_Order_ID);
                    table.ForeignKey(
                        name: "FK_InboundOrders_Warehouses_Warehouse_ID",
                        column: x => x.Warehouse_ID,
                        principalTable: "Warehouses",
                        principalColumn: "Warehouse_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Product_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Warehouse_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Product_ID);
                    table.ForeignKey(
                        name: "FK_Inventories_Warehouses_Warehouse_ID",
                        column: x => x.Warehouse_ID,
                        principalTable: "Warehouses",
                        principalColumn: "Warehouse_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcelOutbounds",
                columns: table => new
                {
                    Order_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Order_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Warehouse_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estimated_Delivery_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ship_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Transport_Days = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recipient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tracking_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference_Order_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creation_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Boxes = table.Column<int>(type: "int", nullable: false),
                    Shipping_Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latest_Information = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tracking_Update_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Internet_Posting_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Delivery_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Related_Adjustment_Order = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelOutbounds", x => x.Order_ID);
                    table.ForeignKey(
                        name: "FK_ParcelOutbounds_Warehouses_Warehouse_ID",
                        column: x => x.Warehouse_ID,
                        principalTable: "Warehouses",
                        principalColumn: "Warehouse_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Billings",
                columns: table => new
                {
                    Billing_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Billing_Account_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    User_ID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billings", x => x.Billing_ID);
                    table.ForeignKey(
                        name: "FK_Billings_BillingAccounts_Billing_Account_ID",
                        column: x => x.Billing_Account_ID,
                        principalTable: "BillingAccounts",
                        principalColumn: "Billing_Account_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Billings_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "User_ID");
                });

            migrationBuilder.CreateTable(
                name: "FreightProductLists",
                columns: table => new
                {
                    Order_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Product_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    FreightOutboundOutbound_Order_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InventoryProduct_ID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreightProductLists", x => new { x.Order_ID, x.Product_ID });
                    table.ForeignKey(
                        name: "FK_FreightProductLists_FreightOutbounds_FreightOutboundOutbound_Order_ID",
                        column: x => x.FreightOutboundOutbound_Order_ID,
                        principalTable: "FreightOutbounds",
                        principalColumn: "Outbound_Order_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FreightProductLists_Inventories_InventoryProduct_ID",
                        column: x => x.InventoryProduct_ID,
                        principalTable: "Inventories",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InboundProductLists",
                columns: table => new
                {
                    Order_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Product_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InboundProductLists", x => new { x.Order_ID, x.Product_ID });
                    table.ForeignKey(
                        name: "FK_InboundProductLists_InboundOrders_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "InboundOrders",
                        principalColumn: "Inbound_Order_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InboundProductLists_Inventories_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "Inventories",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcelProductLists",
                columns: table => new
                {
                    Order_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Product_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelProductLists", x => new { x.Order_ID, x.Product_ID });
                    table.ForeignKey(
                        name: "FK_ParcelProductLists_Inventories_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "Inventories",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParcelProductLists_ParcelOutbounds_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "ParcelOutbounds",
                        principalColumn: "Order_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillingAccounts_User_ID",
                table: "BillingAccounts",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Billings_Billing_Account_ID",
                table: "Billings",
                column: "Billing_Account_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Billings_User_ID",
                table: "Billings",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FreightOutbounds_Warehouse_ID",
                table: "FreightOutbounds",
                column: "Warehouse_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FreightProductLists_FreightOutboundOutbound_Order_ID",
                table: "FreightProductLists",
                column: "FreightOutboundOutbound_Order_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FreightProductLists_InventoryProduct_ID",
                table: "FreightProductLists",
                column: "InventoryProduct_ID");

            migrationBuilder.CreateIndex(
                name: "IX_InboundOrders_Warehouse_ID",
                table: "InboundOrders",
                column: "Warehouse_ID");

            migrationBuilder.CreateIndex(
                name: "IX_InboundProductLists_Product_ID",
                table: "InboundProductLists",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_Warehouse_ID",
                table: "Inventories",
                column: "Warehouse_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOutbounds_Warehouse_ID",
                table: "ParcelOutbounds",
                column: "Warehouse_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelProductLists_Product_ID",
                table: "ParcelProductLists",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_Role_ID",
                table: "UserRoles",
                column: "Role_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Billings");

            migrationBuilder.DropTable(
                name: "Costs");

            migrationBuilder.DropTable(
                name: "FreightProductLists");

            migrationBuilder.DropTable(
                name: "InboundProductLists");

            migrationBuilder.DropTable(
                name: "ParcelProductLists");

            migrationBuilder.DropTable(
                name: "PlatformOrders");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "BillingAccounts");

            migrationBuilder.DropTable(
                name: "FreightOutbounds");

            migrationBuilder.DropTable(
                name: "InboundOrders");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "ParcelOutbounds");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}