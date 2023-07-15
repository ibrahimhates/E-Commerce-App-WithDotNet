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
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
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
                name: "Carts",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
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
                name: "ProductCarts",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    BasketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCarts", x => new { x.ProductId, x.BasketId });
                    table.ForeignKey(
                        name: "FK_ProductCarts_Carts_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Carts",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCarts_Products_ProductId",
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
                    { 1, 0, "f00bc69d-72f4-44ba-8078-d038ab7ef8f3", new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(819), "kullanici1@admin.com", true, "Kullanici1", "user1", false, null, "kullanici1@GMAIL.COM", "KULLANICI1", "AQAAAAIAAYagAAAAEJllNpPZ4khnSPH4pExWGcJp6AgYZ/E3QbNmbFQjiET3CS3qqqjQP/R6jFAss1Qsrw==", "+9053399999991", true, "4e4a0110-2077-47a7-bec4-090021106742", false, "kullanici1" },
                    { 2, 0, "4dd75f4a-1796-4333-bb12-5d03609a1163", new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(828), "kullanici2@admin.com", true, "Kullanici2", "user2", false, null, "kullanici2@GMAIL.COM", "KULLANICI2", "AQAAAAIAAYagAAAAEK99ezj9CvvRxGrYqKnyyFwyOctR+ZZ1LYJkxzpKV1yuy1Xpw74UMlRLcHsMEnahnQ==", "+9053399999991", true, "7d345082-ba07-4751-915b-35da085f92ab", false, "kullanici2" }
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
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "453fcca9-c967-4a43-854d-86f9b0687af0", null, "Admin", "ADMIN" },
                    { "cc06c8fc-6b5b-4741-8543-ef68ea8f801a", null, "User", "USER" }
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
                table: "Carts",
                columns: new[] { "UserId", "Total" },
                values: new object[,]
                {
                    { 1, 200m },
                    { 2, 200m }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "DeliveryStatus", "OrderDate", "PaymentStatus", "TotalAmount", "UserId" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2023, 7, 13, 20, 45, 6, 23, DateTimeKind.Local).AddTicks(9636), false, 100m, 1 },
                    { 2, false, new DateTime(2023, 7, 15, 20, 45, 6, 23, DateTimeKind.Local).AddTicks(9662), true, 100m, 2 },
                    { 3, true, new DateTime(2023, 7, 10, 20, 45, 6, 23, DateTimeKind.Local).AddTicks(9664), true, 100m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "Name", "Price", "StockStatus" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(124), "Description 1", "Product 1", 5686m, true },
                    { 2, 2, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(135), "Description 2", "Product 2", 3704m, true },
                    { 3, 3, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(137), "Description 3", "Product 3", 5802m, true },
                    { 4, 4, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(139), "Description 4", "Product 4", 6904m, true },
                    { 5, 5, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(142), "Description 5", "Product 5", 7858m, true },
                    { 6, 6, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(144), "Description 6", "Product 6", 5264m, true },
                    { 7, 7, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(146), "Description 7", "Product 7", 4554m, true },
                    { 8, 8, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(148), "Description 8", "Product 8", 9118m, true },
                    { 9, 9, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(150), "Description 9", "Product 9", 4069m, true },
                    { 10, 10, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(153), "Description 10", "Product 10", 388m, true },
                    { 11, 11, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(155), "Description 11", "Product 11", 5946m, true },
                    { 12, 12, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(157), "Description 12", "Product 12", 5619m, true },
                    { 13, 13, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(159), "Description 13", "Product 13", 915m, true },
                    { 14, 14, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(161), "Description 14", "Product 14", 7388m, true },
                    { 15, 15, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(162), "Description 15", "Product 15", 4593m, true },
                    { 16, 16, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(164), "Description 16", "Product 16", 1659m, true },
                    { 17, 17, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(191), "Description 17", "Product 17", 7084m, true },
                    { 18, 18, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(194), "Description 18", "Product 18", 4601m, true },
                    { 19, 19, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(196), "Description 19", "Product 19", 1445m, true },
                    { 20, 20, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(198), "Description 20", "Product 20", 1363m, true },
                    { 21, 21, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(200), "Description 21", "Product 21", 5678m, true },
                    { 22, 22, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(202), "Description 22", "Product 22", 464m, true },
                    { 23, 23, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(204), "Description 23", "Product 23", 3120m, true },
                    { 24, 24, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(207), "Description 24", "Product 24", 6152m, true },
                    { 25, 25, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(208), "Description 25", "Product 25", 8408m, true },
                    { 26, 26, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(210), "Description 26", "Product 26", 1404m, true },
                    { 27, 27, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(212), "Description 27", "Product 27", 5455m, true },
                    { 28, 28, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(214), "Description 28", "Product 28", 8139m, true },
                    { 29, 29, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(216), "Description 29", "Product 29", 507m, true },
                    { 30, 30, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(218), "Description 30", "Product 30", 5380m, true },
                    { 31, 1, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(220), "Description 31", "Product 31", 4389m, true },
                    { 32, 2, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(222), "Description 32", "Product 32", 2057m, true },
                    { 33, 3, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(224), "Description 33", "Product 33", 4113m, true },
                    { 34, 4, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(227), "Description 34", "Product 34", 3718m, true },
                    { 35, 5, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(229), "Description 35", "Product 35", 1030m, true },
                    { 36, 6, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(231), "Description 36", "Product 36", 9903m, true },
                    { 37, 7, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(233), "Description 37", "Product 37", 2861m, true },
                    { 38, 8, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(235), "Description 38", "Product 38", 5772m, true },
                    { 39, 9, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(237), "Description 39", "Product 39", 4535m, true },
                    { 40, 10, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(239), "Description 40", "Product 40", 7426m, true },
                    { 41, 11, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(240), "Description 41", "Product 41", 1268m, true },
                    { 42, 12, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(242), "Description 42", "Product 42", 2810m, true },
                    { 43, 13, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(244), "Description 43", "Product 43", 3076m, true },
                    { 44, 14, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(246), "Description 44", "Product 44", 3575m, true },
                    { 45, 15, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(248), "Description 45", "Product 45", 8686m, true },
                    { 46, 16, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(250), "Description 46", "Product 46", 1465m, true },
                    { 47, 17, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(252), "Description 47", "Product 47", 6570m, true },
                    { 48, 18, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(254), "Description 48", "Product 48", 6293m, true },
                    { 49, 19, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(256), "Description 49", "Product 49", 8427m, true },
                    { 50, 20, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(257), "Description 50", "Product 50", 9285m, true },
                    { 51, 21, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(259), "Description 51", "Product 51", 2419m, true },
                    { 52, 22, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(261), "Description 52", "Product 52", 1377m, true },
                    { 53, 23, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(263), "Description 53", "Product 53", 2781m, true },
                    { 54, 24, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(286), "Description 54", "Product 54", 3705m, true },
                    { 55, 25, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(288), "Description 55", "Product 55", 2618m, true },
                    { 56, 26, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(289), "Description 56", "Product 56", 1878m, true },
                    { 57, 27, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(291), "Description 57", "Product 57", 5895m, true },
                    { 58, 28, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(293), "Description 58", "Product 58", 8888m, true },
                    { 59, 29, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(295), "Description 59", "Product 59", 5912m, true },
                    { 60, 30, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(297), "Description 60", "Product 60", 3294m, true },
                    { 61, 1, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(299), "Description 61", "Product 61", 3119m, true },
                    { 62, 2, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(301), "Description 62", "Product 62", 157m, true },
                    { 63, 3, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(303), "Description 63", "Product 63", 709m, true },
                    { 64, 4, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(305), "Description 64", "Product 64", 4715m, true },
                    { 65, 5, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(307), "Description 65", "Product 65", 6230m, true },
                    { 66, 6, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(310), "Description 66", "Product 66", 6566m, true },
                    { 67, 7, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(312), "Description 67", "Product 67", 4880m, true },
                    { 68, 8, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(314), "Description 68", "Product 68", 6419m, true },
                    { 69, 9, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(315), "Description 69", "Product 69", 6941m, true },
                    { 70, 10, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(317), "Description 70", "Product 70", 4122m, true },
                    { 71, 11, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(319), "Description 71", "Product 71", 2320m, true },
                    { 72, 12, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(321), "Description 72", "Product 72", 5120m, true },
                    { 73, 13, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(323), "Description 73", "Product 73", 3462m, true },
                    { 74, 14, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(325), "Description 74", "Product 74", 8768m, true },
                    { 75, 15, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(327), "Description 75", "Product 75", 7158m, true },
                    { 76, 16, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(328), "Description 76", "Product 76", 6172m, true },
                    { 77, 17, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(330), "Description 77", "Product 77", 5563m, true },
                    { 78, 18, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(332), "Description 78", "Product 78", 870m, true },
                    { 79, 19, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(334), "Description 79", "Product 79", 1654m, true },
                    { 80, 20, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(336), "Description 80", "Product 80", 8351m, true },
                    { 81, 21, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(338), "Description 81", "Product 81", 3587m, true },
                    { 82, 22, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(340), "Description 82", "Product 82", 6242m, true },
                    { 83, 23, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(341), "Description 83", "Product 83", 1883m, true },
                    { 84, 24, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(343), "Description 84", "Product 84", 6102m, true },
                    { 85, 25, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(345), "Description 85", "Product 85", 9937m, true },
                    { 86, 26, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(347), "Description 86", "Product 86", 8644m, true },
                    { 87, 27, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(349), "Description 87", "Product 87", 9905m, true },
                    { 88, 28, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(351), "Description 88", "Product 88", 2738m, true },
                    { 89, 29, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(376), "Description 89", "Product 89", 4505m, true },
                    { 90, 30, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(378), "Description 90", "Product 90", 4404m, true },
                    { 91, 1, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(380), "Description 91", "Product 91", 472m, true },
                    { 92, 2, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(382), "Description 92", "Product 92", 4259m, true },
                    { 93, 3, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(384), "Description 93", "Product 93", 293m, true },
                    { 94, 4, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(386), "Description 94", "Product 94", 7765m, true },
                    { 95, 5, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(388), "Description 95", "Product 95", 3379m, true },
                    { 96, 6, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(390), "Description 96", "Product 96", 7572m, true },
                    { 97, 7, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(393), "Description 97", "Product 97", 3290m, true },
                    { 98, 8, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(394), "Description 98", "Product 98", 8190m, true },
                    { 99, 9, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(397), "Description 99", "Product 99", 9876m, true },
                    { 100, 10, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(399), "Description 100", "Product 100", 9861m, true },
                    { 101, 11, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(402), "Description 101", "Product 101", 5587m, true },
                    { 102, 12, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(404), "Description 102", "Product 102", 6004m, true },
                    { 103, 13, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(405), "Description 103", "Product 103", 8204m, true },
                    { 104, 14, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(408), "Description 104", "Product 104", 7298m, true },
                    { 105, 15, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(410), "Description 105", "Product 105", 4361m, true },
                    { 106, 16, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(411), "Description 106", "Product 106", 5431m, true },
                    { 107, 17, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(413), "Description 107", "Product 107", 5429m, true },
                    { 108, 18, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(415), "Description 108", "Product 108", 5354m, true },
                    { 109, 19, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(417), "Description 109", "Product 109", 2068m, true },
                    { 110, 20, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(419), "Description 110", "Product 110", 9275m, true },
                    { 111, 21, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(421), "Description 111", "Product 111", 2721m, true },
                    { 112, 22, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(423), "Description 112", "Product 112", 3585m, true },
                    { 113, 23, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(425), "Description 113", "Product 113", 3675m, true },
                    { 114, 24, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(427), "Description 114", "Product 114", 9740m, true },
                    { 115, 25, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(429), "Description 115", "Product 115", 2798m, true },
                    { 116, 26, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(431), "Description 116", "Product 116", 435m, true },
                    { 117, 27, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(433), "Description 117", "Product 117", 9296m, true },
                    { 118, 28, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(435), "Description 118", "Product 118", 7267m, true },
                    { 119, 29, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(437), "Description 119", "Product 119", 3516m, true },
                    { 120, 30, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(439), "Description 120", "Product 120", 8432m, true },
                    { 121, 1, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(441), "Description 121", "Product 121", 4319m, true },
                    { 122, 2, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(443), "Description 122", "Product 122", 819m, true },
                    { 123, 3, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(445), "Description 123", "Product 123", 3292m, true },
                    { 124, 4, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(446), "Description 124", "Product 124", 6080m, true },
                    { 125, 5, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(449), "Description 125", "Product 125", 995m, true },
                    { 126, 6, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(451), "Description 126", "Product 126", 9236m, true },
                    { 127, 7, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(453), "Description 127", "Product 127", 1746m, true },
                    { 128, 8, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(454), "Description 128", "Product 128", 3504m, true },
                    { 129, 9, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(456), "Description 129", "Product 129", 8730m, true },
                    { 130, 10, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(480), "Description 130", "Product 130", 6967m, true },
                    { 131, 11, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(482), "Description 131", "Product 131", 173m, true },
                    { 132, 12, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(484), "Description 132", "Product 132", 7001m, true },
                    { 133, 13, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(486), "Description 133", "Product 133", 9334m, true },
                    { 134, 14, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(488), "Description 134", "Product 134", 3191m, true },
                    { 135, 15, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(490), "Description 135", "Product 135", 7306m, true },
                    { 136, 16, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(492), "Description 136", "Product 136", 9016m, true },
                    { 137, 17, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(494), "Description 137", "Product 137", 8930m, true },
                    { 138, 18, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(496), "Description 138", "Product 138", 4182m, true },
                    { 139, 19, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(498), "Description 139", "Product 139", 9215m, true },
                    { 140, 20, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(500), "Description 140", "Product 140", 7451m, true },
                    { 141, 21, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(502), "Description 141", "Product 141", 5202m, true },
                    { 142, 22, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(503), "Description 142", "Product 142", 3130m, true },
                    { 143, 23, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(505), "Description 143", "Product 143", 1862m, true },
                    { 144, 24, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(507), "Description 144", "Product 144", 2849m, true },
                    { 145, 25, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(509), "Description 145", "Product 145", 1152m, true },
                    { 146, 26, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(511), "Description 146", "Product 146", 5950m, true },
                    { 147, 27, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(514), "Description 147", "Product 147", 3750m, true },
                    { 148, 28, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(516), "Description 148", "Product 148", 1948m, true },
                    { 149, 29, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(518), "Description 149", "Product 149", 1780m, true },
                    { 150, 30, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(520), "Description 150", "Product 150", 5453m, true },
                    { 151, 1, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(522), "Description 151", "Product 151", 6474m, true },
                    { 152, 2, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(524), "Description 152", "Product 152", 7474m, true },
                    { 153, 3, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(525), "Description 153", "Product 153", 8178m, true },
                    { 154, 4, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(527), "Description 154", "Product 154", 9576m, true },
                    { 155, 5, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(529), "Description 155", "Product 155", 3378m, true },
                    { 156, 6, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(531), "Description 156", "Product 156", 4276m, true },
                    { 157, 7, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(533), "Description 157", "Product 157", 1189m, true },
                    { 158, 8, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(535), "Description 158", "Product 158", 1209m, true },
                    { 159, 9, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(537), "Description 159", "Product 159", 4958m, true },
                    { 160, 10, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(575), "Description 160", "Product 160", 9183m, true },
                    { 161, 11, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(577), "Description 161", "Product 161", 5676m, true },
                    { 162, 12, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(580), "Description 162", "Product 162", 5496m, true },
                    { 163, 13, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(582), "Description 163", "Product 163", 7266m, true },
                    { 164, 14, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(584), "Description 164", "Product 164", 8476m, true },
                    { 165, 15, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(586), "Description 165", "Product 165", 6253m, true },
                    { 166, 16, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(588), "Description 166", "Product 166", 7794m, true },
                    { 167, 17, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(589), "Description 167", "Product 167", 1623m, true },
                    { 168, 18, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(592), "Description 168", "Product 168", 3562m, true },
                    { 169, 19, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(594), "Description 169", "Product 169", 3650m, true },
                    { 170, 20, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(596), "Description 170", "Product 170", 5413m, true },
                    { 171, 21, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(597), "Description 171", "Product 171", 8759m, true },
                    { 172, 22, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(599), "Description 172", "Product 172", 7489m, true },
                    { 173, 23, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(601), "Description 173", "Product 173", 249m, true },
                    { 174, 24, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(603), "Description 174", "Product 174", 7918m, true },
                    { 175, 25, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(605), "Description 175", "Product 175", 5005m, true },
                    { 176, 26, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(607), "Description 176", "Product 176", 7107m, true },
                    { 177, 27, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(609), "Description 177", "Product 177", 7192m, true },
                    { 178, 28, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(610), "Description 178", "Product 178", 2378m, true },
                    { 179, 29, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(612), "Description 179", "Product 179", 5005m, true },
                    { 180, 30, new DateTime(2023, 7, 15, 20, 45, 6, 24, DateTimeKind.Local).AddTicks(614), "Description 180", "Product 180", 7827m, true }
                });

            migrationBuilder.InsertData(
                table: "ProductCarts",
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
                name: "IX_ProductCarts_BasketId",
                table: "ProductCarts",
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
                name: "IdentityRole");

            migrationBuilder.DropTable(
                name: "ProductCarts");

            migrationBuilder.DropTable(
                name: "ProductOrder");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

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
