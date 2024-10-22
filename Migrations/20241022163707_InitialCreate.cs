using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cost_Based_Charges",
                columns: table => new
                {
                    Cost_Charge_ID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cost_Based_Charges", x => x.Cost_Charge_ID);
                });

            migrationBuilder.CreateTable(
                name: "Costs",
                columns: table => new
                {
                    Cost_ID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costs", x => x.Cost_ID);
                });

            migrationBuilder.CreateTable(
                name: "Order_Based_Charges",
                columns: table => new
                {
                    Order_Charge_ID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Based_Charges", x => x.Order_Charge_ID);
                });

            migrationBuilder.CreateTable(
                name: "PlatformOrders",
                columns: table => new
                {
                    Order_ID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformOrders", x => x.Order_ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Role_ID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Role_Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Role_ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_ID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
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
                    Warehouse_ID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Warehouse_ID);
                });

            migrationBuilder.CreateTable(
                name: "BillingAccounts",
                columns: table => new
                {
                    Billing_Account_ID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    User_ID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    User_ID = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Role_ID = table.Column<string>(type: "nvarchar(25)", nullable: false)
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
                    Outbound_Order_ID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Order_Type = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Order_Status = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Warehouse_ID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Product_Quantity = table.Column<int>(type: "int", nullable: false),
                    Creation_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estimated_Delivery_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Order_Ship_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Recipient = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Recipient_Post_Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Destination_Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Shipping_Company = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Transport_Days = table.Column<int>(type: "int", nullable: false),
                    Related_Adjustment_Order = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Tracking_Number = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Reference_Order_Number = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FBA_Shipment_ID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    FBA_Tracking_Number = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Outbound_Method = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreightOutbounds", x => x.Outbound_Order_ID);
                    table.ForeignKey(
                        name: "FK_FreightOutbounds_Users_Creator",
                        column: x => x.Creator,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FreightOutbounds_Warehouses_Warehouse_ID",
                        column: x => x.Warehouse_ID,
                        principalTable: "Warehouses",
                        principalColumn: "Warehouse_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InboundOrders",
                columns: table => new
                {
                    Inbound_Order_ID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Order_Status = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Warehouse_ID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Estimated_Arrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Product_Quantity = table.Column<int>(type: "int", nullable: false),
                    Creation_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Boxes = table.Column<int>(type: "int", nullable: false),
                    Inbound_Type = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Tracking_Number = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Reference_Order_Number = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Arrival_Method = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InboundOrders", x => x.Inbound_Order_ID);
                    table.ForeignKey(
                        name: "FK_InboundOrders_Users_Creator",
                        column: x => x.Creator,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InboundOrders_Warehouses_Warehouse_ID",
                        column: x => x.Warehouse_ID,
                        principalTable: "Warehouses",
                        principalColumn: "Warehouse_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Product_ID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Warehouse_ID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Product_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Product_Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Product_ID);
                    table.ForeignKey(
                        name: "FK_Inventories_Warehouses_Warehouse_ID",
                        column: x => x.Warehouse_ID,
                        principalTable: "Warehouses",
                        principalColumn: "Warehouse_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParcelOutbounds",
                columns: table => new
                {
                    Order_ID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Order_Type = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Order_Status = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Warehouse_ID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estimated_Delivery_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ship_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Transport_Days = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Recipient = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Tracking_Number = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Reference_Order_Number = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Creation_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Boxes = table.Column<int>(type: "int", nullable: false),
                    Shipping_Company = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Latest_Information = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Tracking_Update_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Internet_Posting_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Delivery_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Related_Adjustment_Order = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelOutbounds", x => x.Order_ID);
                    table.ForeignKey(
                        name: "FK_ParcelOutbounds_Users_Creator",
                        column: x => x.Creator,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParcelOutbounds_Warehouses_Warehouse_ID",
                        column: x => x.Warehouse_ID,
                        principalTable: "Warehouses",
                        principalColumn: "Warehouse_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Billings",
                columns: table => new
                {
                    Billing_ID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Billing_Account_ID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    User_ID = table.Column<string>(type: "nvarchar(25)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billings", x => x.Billing_ID);
                    table.ForeignKey(
                        name: "FK_Billings_BillingAccounts_Billing_Account_ID",
                        column: x => x.Billing_Account_ID,
                        principalTable: "BillingAccounts",
                        principalColumn: "Billing_Account_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Billings_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "User_ID");
                });

            migrationBuilder.CreateTable(
                name: "Cost_Based_Billings",
                columns: table => new
                {
                    Billing_Account_ID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Cost_Charge_ID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cost_Based_Billings", x => new { x.Billing_Account_ID, x.Cost_Charge_ID });
                    table.ForeignKey(
                        name: "FK_Cost_Based_Billings_BillingAccounts_Billing_Account_ID",
                        column: x => x.Billing_Account_ID,
                        principalTable: "BillingAccounts",
                        principalColumn: "Billing_Account_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cost_Based_Billings_Cost_Based_Charges_Cost_Charge_ID",
                        column: x => x.Cost_Charge_ID,
                        principalTable: "Cost_Based_Charges",
                        principalColumn: "Cost_Charge_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order_Based_Billings",
                columns: table => new
                {
                    Billing_Account_ID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Order_Charge_ID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Based_Billings", x => new { x.Billing_Account_ID, x.Order_Charge_ID });
                    table.ForeignKey(
                        name: "FK_Order_Based_Billings_BillingAccounts_Billing_Account_ID",
                        column: x => x.Billing_Account_ID,
                        principalTable: "BillingAccounts",
                        principalColumn: "Billing_Account_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Based_Billings_Order_Based_Charges_Order_Charge_ID",
                        column: x => x.Order_Charge_ID,
                        principalTable: "Order_Based_Charges",
                        principalColumn: "Order_Charge_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FreightProductLists",
                columns: table => new
                {
                    Order_ID = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Product_ID = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreightProductLists", x => new { x.Order_ID, x.Product_ID });
                    table.ForeignKey(
                        name: "FK_FreightProductLists_FreightOutbounds_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "FreightOutbounds",
                        principalColumn: "Outbound_Order_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FreightProductLists_Inventories_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "Inventories",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InboundProductLists",
                columns: table => new
                {
                    Order_ID = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Product_ID = table.Column<string>(type: "nvarchar(25)", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InboundProductLists_Inventories_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "Inventories",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParcelProductLists",
                columns: table => new
                {
                    Order_ID = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Product_ID = table.Column<string>(type: "nvarchar(25)", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParcelProductLists_ParcelOutbounds_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "ParcelOutbounds",
                        principalColumn: "Order_ID",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Cost_Based_Billings_Cost_Charge_ID",
                table: "Cost_Based_Billings",
                column: "Cost_Charge_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FreightOutbounds_Creator",
                table: "FreightOutbounds",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_FreightOutbounds_Warehouse_ID",
                table: "FreightOutbounds",
                column: "Warehouse_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FreightProductLists_Product_ID",
                table: "FreightProductLists",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_InboundOrders_Creator",
                table: "InboundOrders",
                column: "Creator");

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
                name: "IX_Order_Based_Billings_Order_Charge_ID",
                table: "Order_Based_Billings",
                column: "Order_Charge_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOutbounds_Creator",
                table: "ParcelOutbounds",
                column: "Creator");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Billings");

            migrationBuilder.DropTable(
                name: "Cost_Based_Billings");

            migrationBuilder.DropTable(
                name: "Costs");

            migrationBuilder.DropTable(
                name: "FreightProductLists");

            migrationBuilder.DropTable(
                name: "InboundProductLists");

            migrationBuilder.DropTable(
                name: "Order_Based_Billings");

            migrationBuilder.DropTable(
                name: "ParcelProductLists");

            migrationBuilder.DropTable(
                name: "PlatformOrders");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Cost_Based_Charges");

            migrationBuilder.DropTable(
                name: "FreightOutbounds");

            migrationBuilder.DropTable(
                name: "InboundOrders");

            migrationBuilder.DropTable(
                name: "BillingAccounts");

            migrationBuilder.DropTable(
                name: "Order_Based_Charges");

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
