using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class _init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Baskets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PaymentStatus = table.Column<bool>(type: "bit", nullable: false),
                    DeliveryStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    StockStatus = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AddressName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Addresses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Orders_UserId",
                        column: x => x.UserId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductBaskets",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    BasketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBaskets", x => new { x.ProductId, x.BasketId });
                    table.ForeignKey(
                        name: "FK_ProductBaskets_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductBaskets_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOrder",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrder", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOrder_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "a9645daf-f6bd-4538-a6d0-fa9da3a77e1b", new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2680), "kullanici1@admin.com", true, "Kullanici1", "user1", false, null, "kullanici1@GMAIL.COM", "KULLANICI1", "AQAAAAIAAYagAAAAEBPuYEOPDvSLZwaQqqxSK57ysiTQupNV00HI1qvVSEztvK7pI3cLujw+fMY4gp1GWg==", "+9053399999991", true, "29295992-e7b2-4ef6-9880-e293fec0eac1", false, "kullanici1" },
                    { 2, 0, "c628cee0-3df6-4e48-8909-48c257f7c08f", new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2689), "kullanici2@admin.com", true, "Kullanici2", "user2", false, null, "kullanici2@GMAIL.COM", "KULLANICI2", "AQAAAAIAAYagAAAAEAF708c8rTFH/i3g9cec8s2vOvoqBxcZu/lpHtFQdXmi2gr2w6vxbei0olIfufr4Vw==", "+9053399999991", true, "93b86b6f-9eb4-41fb-834e-b57a0ac4ac04", false, "kullanici2" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Category 1" },
                    { 2, "Category 2" },
                    { 3, "Category 3" },
                    { 4, "Category 4" },
                    { 5, "Category 5" },
                    { 6, "Category 6" },
                    { 7, "Category 7" },
                    { 8, "Category 8" },
                    { 9, "Category 9" },
                    { 10, "Category 10" },
                    { 11, "Category 11" },
                    { 12, "Category 12" },
                    { 13, "Category 13" },
                    { 14, "Category 14" },
                    { 15, "Category 15" },
                    { 16, "Category 16" },
                    { 17, "Category 17" },
                    { 18, "Category 18" },
                    { 19, "Category 19" },
                    { 20, "Category 20" },
                    { 21, "Category 21" },
                    { 22, "Category 22" },
                    { 23, "Category 23" },
                    { 24, "Category 24" },
                    { 25, "Category 25" },
                    { 26, "Category 26" },
                    { 27, "Category 27" },
                    { 28, "Category 28" },
                    { 29, "Category 29" },
                    { 30, "Category 30" }
                });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "UserId", "Total" },
                values: new object[,]
                {
                    { 1, 200m },
                    { 2, 200m }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AddressId", "DeliveryStatus", "OrderDate", "PaymentStatus", "TotalAmount", "UserId" },
                values: new object[,]
                {
                    { 1, 1, false, new DateTime(2023, 7, 9, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1018), false, 100m, 1 },
                    { 2, 2, false, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1036), true, 100m, 2 },
                    { 3, 2, true, new DateTime(2023, 7, 6, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1038), true, 100m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "Name", "Price", "StockStatus" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1570), "Description 1", "Product 1", 4609m, true },
                    { 2, 2, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1579), "Description 2", "Product 2", 5049m, true },
                    { 3, 3, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1582), "Description 3", "Product 3", 3813m, true },
                    { 4, 4, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1583), "Description 4", "Product 4", 7066m, true },
                    { 5, 5, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1585), "Description 5", "Product 5", 8550m, true },
                    { 6, 6, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1588), "Description 6", "Product 6", 9413m, true },
                    { 7, 7, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1590), "Description 7", "Product 7", 2768m, true },
                    { 8, 8, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1591), "Description 8", "Product 8", 8290m, true },
                    { 9, 9, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1593), "Description 9", "Product 9", 1655m, true },
                    { 10, 10, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1596), "Description 10", "Product 10", 5885m, true },
                    { 11, 11, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1692), "Description 11", "Product 11", 6046m, true },
                    { 12, 12, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1694), "Description 12", "Product 12", 473m, true },
                    { 13, 13, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1695), "Description 13", "Product 13", 4996m, true },
                    { 14, 14, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1697), "Description 14", "Product 14", 1461m, true },
                    { 15, 15, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1699), "Description 15", "Product 15", 1147m, true },
                    { 16, 16, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1700), "Description 16", "Product 16", 2205m, true },
                    { 17, 17, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1702), "Description 17", "Product 17", 7761m, true },
                    { 18, 18, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1705), "Description 18", "Product 18", 6679m, true },
                    { 19, 19, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1706), "Description 19", "Product 19", 6386m, true },
                    { 20, 20, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1708), "Description 20", "Product 20", 2386m, true },
                    { 21, 21, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1709), "Description 21", "Product 21", 3937m, true },
                    { 22, 22, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1711), "Description 22", "Product 22", 3732m, true },
                    { 23, 23, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1712), "Description 23", "Product 23", 1217m, true },
                    { 24, 24, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1714), "Description 24", "Product 24", 5450m, true },
                    { 25, 25, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1716), "Description 25", "Product 25", 5900m, true },
                    { 26, 26, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1717), "Description 26", "Product 26", 8646m, true },
                    { 27, 27, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1719), "Description 27", "Product 27", 8165m, true },
                    { 28, 28, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1720), "Description 28", "Product 28", 8769m, true },
                    { 29, 29, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1722), "Description 29", "Product 29", 7194m, true },
                    { 30, 30, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1723), "Description 30", "Product 30", 9804m, true },
                    { 31, 1, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1725), "Description 31", "Product 31", 9106m, true },
                    { 32, 2, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1726), "Description 32", "Product 32", 6912m, true },
                    { 33, 3, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1728), "Description 33", "Product 33", 8874m, true },
                    { 34, 4, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1731), "Description 34", "Product 34", 9408m, true },
                    { 35, 5, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1732), "Description 35", "Product 35", 2178m, true },
                    { 36, 6, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1734), "Description 36", "Product 36", 3150m, true },
                    { 37, 7, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1735), "Description 37", "Product 37", 1362m, true },
                    { 38, 8, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1736), "Description 38", "Product 38", 7724m, true },
                    { 39, 9, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1738), "Description 39", "Product 39", 8154m, true },
                    { 40, 10, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1739), "Description 40", "Product 40", 8361m, true },
                    { 41, 11, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1741), "Description 41", "Product 41", 1651m, true },
                    { 42, 12, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1742), "Description 42", "Product 42", 6427m, true },
                    { 43, 13, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1744), "Description 43", "Product 43", 5281m, true },
                    { 44, 14, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1745), "Description 44", "Product 44", 2178m, true },
                    { 45, 15, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1747), "Description 45", "Product 45", 4041m, true },
                    { 46, 16, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1748), "Description 46", "Product 46", 2337m, true },
                    { 47, 17, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1750), "Description 47", "Product 47", 4369m, true },
                    { 48, 18, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1961), "Description 48", "Product 48", 4954m, true },
                    { 49, 19, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1963), "Description 49", "Product 49", 3257m, true },
                    { 50, 20, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1965), "Description 50", "Product 50", 3782m, true },
                    { 51, 21, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1967), "Description 51", "Product 51", 3917m, true },
                    { 52, 22, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1968), "Description 52", "Product 52", 7323m, true },
                    { 53, 23, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1970), "Description 53", "Product 53", 9312m, true },
                    { 54, 24, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1972), "Description 54", "Product 54", 1613m, true },
                    { 55, 25, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1973), "Description 55", "Product 55", 2677m, true },
                    { 56, 26, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1975), "Description 56", "Product 56", 8553m, true },
                    { 57, 27, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1976), "Description 57", "Product 57", 359m, true },
                    { 58, 28, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1978), "Description 58", "Product 58", 5319m, true },
                    { 59, 29, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1980), "Description 59", "Product 59", 1668m, true },
                    { 60, 30, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1981), "Description 60", "Product 60", 3809m, true },
                    { 61, 1, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1983), "Description 61", "Product 61", 1969m, true },
                    { 62, 2, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1985), "Description 62", "Product 62", 3574m, true },
                    { 63, 3, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1986), "Description 63", "Product 63", 7500m, true },
                    { 64, 4, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1988), "Description 64", "Product 64", 6771m, true },
                    { 65, 5, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1989), "Description 65", "Product 65", 7038m, true },
                    { 66, 6, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1992), "Description 66", "Product 66", 3437m, true },
                    { 67, 7, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1994), "Description 67", "Product 67", 8937m, true },
                    { 68, 8, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1996), "Description 68", "Product 68", 733m, true },
                    { 69, 9, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1997), "Description 69", "Product 69", 2894m, true },
                    { 70, 10, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(1999), "Description 70", "Product 70", 8345m, true },
                    { 71, 11, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2000), "Description 71", "Product 71", 755m, true },
                    { 72, 12, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2002), "Description 72", "Product 72", 3679m, true },
                    { 73, 13, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2004), "Description 73", "Product 73", 6015m, true },
                    { 74, 14, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2005), "Description 74", "Product 74", 4126m, true },
                    { 75, 15, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2007), "Description 75", "Product 75", 8301m, true },
                    { 76, 16, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2009), "Description 76", "Product 76", 106m, true },
                    { 77, 17, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2011), "Description 77", "Product 77", 2997m, true },
                    { 78, 18, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2013), "Description 78", "Product 78", 388m, true },
                    { 79, 19, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2014), "Description 79", "Product 79", 2186m, true },
                    { 80, 20, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2016), "Description 80", "Product 80", 7478m, true },
                    { 81, 21, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2018), "Description 81", "Product 81", 5541m, true },
                    { 82, 22, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2019), "Description 82", "Product 82", 9391m, true },
                    { 83, 23, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2040), "Description 83", "Product 83", 9590m, true },
                    { 84, 24, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2042), "Description 84", "Product 84", 6856m, true },
                    { 85, 25, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2044), "Description 85", "Product 85", 6243m, true },
                    { 86, 26, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2046), "Description 86", "Product 86", 927m, true },
                    { 87, 27, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2048), "Description 87", "Product 87", 2122m, true },
                    { 88, 28, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2049), "Description 88", "Product 88", 2936m, true },
                    { 89, 29, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2051), "Description 89", "Product 89", 9242m, true },
                    { 90, 30, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2053), "Description 90", "Product 90", 2606m, true },
                    { 91, 1, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2054), "Description 91", "Product 91", 7161m, true },
                    { 92, 2, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2056), "Description 92", "Product 92", 9963m, true },
                    { 93, 3, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2058), "Description 93", "Product 93", 1006m, true },
                    { 94, 4, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2059), "Description 94", "Product 94", 4198m, true },
                    { 95, 5, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2061), "Description 95", "Product 95", 3168m, true },
                    { 96, 6, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2062), "Description 96", "Product 96", 7101m, true },
                    { 97, 7, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2064), "Description 97", "Product 97", 4531m, true },
                    { 98, 8, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2065), "Description 98", "Product 98", 3028m, true },
                    { 99, 9, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2067), "Description 99", "Product 99", 7304m, true },
                    { 100, 10, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2069), "Description 100", "Product 100", 2549m, true },
                    { 101, 11, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2071), "Description 101", "Product 101", 3676m, true },
                    { 102, 12, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2072), "Description 102", "Product 102", 3011m, true },
                    { 103, 13, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2074), "Description 103", "Product 103", 1453m, true },
                    { 104, 14, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2076), "Description 104", "Product 104", 9085m, true },
                    { 105, 15, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2077), "Description 105", "Product 105", 6526m, true },
                    { 106, 16, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2079), "Description 106", "Product 106", 5313m, true },
                    { 107, 17, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2080), "Description 107", "Product 107", 8008m, true },
                    { 108, 18, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2105), "Description 108", "Product 108", 9874m, true },
                    { 109, 19, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2108), "Description 109", "Product 109", 5942m, true },
                    { 110, 20, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2109), "Description 110", "Product 110", 709m, true },
                    { 111, 21, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2111), "Description 111", "Product 111", 1025m, true },
                    { 112, 22, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2113), "Description 112", "Product 112", 8482m, true },
                    { 113, 23, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2115), "Description 113", "Product 113", 8859m, true },
                    { 114, 24, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2117), "Description 114", "Product 114", 3592m, true },
                    { 115, 25, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2118), "Description 115", "Product 115", 1313m, true },
                    { 116, 26, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2120), "Description 116", "Product 116", 6917m, true },
                    { 117, 27, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2122), "Description 117", "Product 117", 3263m, true },
                    { 118, 28, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2124), "Description 118", "Product 118", 9561m, true },
                    { 119, 29, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2125), "Description 119", "Product 119", 4449m, true },
                    { 120, 30, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2127), "Description 120", "Product 120", 435m, true },
                    { 121, 1, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2129), "Description 121", "Product 121", 8891m, true },
                    { 122, 2, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2130), "Description 122", "Product 122", 3483m, true },
                    { 123, 3, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2132), "Description 123", "Product 123", 4326m, true },
                    { 124, 4, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2195), "Description 124", "Product 124", 1337m, true },
                    { 125, 5, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2197), "Description 125", "Product 125", 5258m, true },
                    { 126, 6, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2198), "Description 126", "Product 126", 3615m, true },
                    { 127, 7, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2200), "Description 127", "Product 127", 6741m, true },
                    { 128, 8, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2201), "Description 128", "Product 128", 9570m, true },
                    { 129, 9, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2203), "Description 129", "Product 129", 6844m, true },
                    { 130, 10, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2206), "Description 130", "Product 130", 7296m, true },
                    { 131, 11, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2207), "Description 131", "Product 131", 1174m, true },
                    { 132, 12, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2209), "Description 132", "Product 132", 4782m, true },
                    { 133, 13, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2210), "Description 133", "Product 133", 6761m, true },
                    { 134, 14, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2212), "Description 134", "Product 134", 94m, true },
                    { 135, 15, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2213), "Description 135", "Product 135", 1394m, true },
                    { 136, 16, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2215), "Description 136", "Product 136", 4933m, true },
                    { 137, 17, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2216), "Description 137", "Product 137", 5425m, true },
                    { 138, 18, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2218), "Description 138", "Product 138", 3812m, true },
                    { 139, 19, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2219), "Description 139", "Product 139", 9210m, true },
                    { 140, 20, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2221), "Description 140", "Product 140", 9883m, true },
                    { 141, 21, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2222), "Description 141", "Product 141", 7457m, true },
                    { 142, 22, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2224), "Description 142", "Product 142", 3647m, true },
                    { 143, 23, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2225), "Description 143", "Product 143", 1542m, true },
                    { 144, 24, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2226), "Description 144", "Product 144", 6717m, true },
                    { 145, 25, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2228), "Description 145", "Product 145", 4433m, true },
                    { 146, 26, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2229), "Description 146", "Product 146", 8776m, true },
                    { 147, 27, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2231), "Description 147", "Product 147", 3632m, true },
                    { 148, 28, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2233), "Description 148", "Product 148", 9926m, true },
                    { 149, 29, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2234), "Description 149", "Product 149", 5776m, true },
                    { 150, 30, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2235), "Description 150", "Product 150", 6055m, true },
                    { 151, 1, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2237), "Description 151", "Product 151", 6291m, true },
                    { 152, 2, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2239), "Description 152", "Product 152", 3828m, true },
                    { 153, 3, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2240), "Description 153", "Product 153", 9414m, true },
                    { 154, 4, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2241), "Description 154", "Product 154", 6961m, true },
                    { 155, 5, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2271), "Description 155", "Product 155", 6619m, true },
                    { 156, 6, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2273), "Description 156", "Product 156", 360m, true },
                    { 157, 7, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2275), "Description 157", "Product 157", 2962m, true },
                    { 158, 8, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2276), "Description 158", "Product 158", 3920m, true },
                    { 159, 9, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2278), "Description 159", "Product 159", 2972m, true },
                    { 160, 10, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2279), "Description 160", "Product 160", 2123m, true },
                    { 161, 11, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2281), "Description 161", "Product 161", 8237m, true },
                    { 162, 12, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2282), "Description 162", "Product 162", 1255m, true },
                    { 163, 13, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2284), "Description 163", "Product 163", 8662m, true },
                    { 164, 14, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2286), "Description 164", "Product 164", 1290m, true },
                    { 165, 15, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2287), "Description 165", "Product 165", 8165m, true },
                    { 166, 16, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2289), "Description 166", "Product 166", 2565m, true },
                    { 167, 17, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2290), "Description 167", "Product 167", 6000m, true },
                    { 168, 18, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2292), "Description 168", "Product 168", 416m, true },
                    { 169, 19, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2293), "Description 169", "Product 169", 8039m, true },
                    { 170, 20, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2295), "Description 170", "Product 170", 805m, true },
                    { 171, 21, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2297), "Description 171", "Product 171", 3645m, true },
                    { 172, 22, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2298), "Description 172", "Product 172", 6014m, true },
                    { 173, 23, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2299), "Description 173", "Product 173", 6987m, true },
                    { 174, 24, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2315), "Description 174", "Product 174", 6325m, true },
                    { 175, 25, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2317), "Description 175", "Product 175", 8324m, true },
                    { 176, 26, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2319), "Description 176", "Product 176", 5579m, true },
                    { 177, 27, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2321), "Description 177", "Product 177", 5539m, true },
                    { 178, 28, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2322), "Description 178", "Product 178", 7400m, true },
                    { 179, 29, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2324), "Description 179", "Product 179", 713m, true },
                    { 180, 30, new DateTime(2023, 7, 11, 19, 50, 22, 998, DateTimeKind.Local).AddTicks(2326), "Description 180", "Product 180", 5696m, true }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "UserId", "AddressName" },
                values: new object[,]
                {
                    { 1, "This is a address for kullanici1" },
                    { 2, "This is a address for kullanici2" }
                });

            migrationBuilder.InsertData(
                table: "ProductBaskets",
                columns: new[] { "BasketId", "ProductId" },
                values: new object[,]
                {
                    { 1, 22 },
                    { 1, 33 },
                    { 2, 33 },
                    { 1, 54 },
                    { 1, 55 },
                    { 2, 88 },
                    { 2, 152 }
                });

            migrationBuilder.InsertData(
                table: "ProductOrder",
                columns: new[] { "OrderId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 4 },
                    { 1, 7 },
                    { 1, 34 },
                    { 2, 14 },
                    { 2, 22 },
                    { 2, 55 },
                    { 2, 88 },
                    { 2, 123 },
                    { 3, 89 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBaskets_BasketId",
                table: "ProductBaskets",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrder_ProductId",
                table: "ProductOrder",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ProductBaskets");

            migrationBuilder.DropTable(
                name: "ProductOrder");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
