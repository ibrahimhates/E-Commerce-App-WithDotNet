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
                    { 1, 0, "5bdf33cc-e04e-4e4f-aa52-410c2fc95903", new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5550), "kullanici1@admin.com", true, "Kullanici1", "user1", false, null, "kullanici1@GMAIL.COM", "KULLANICI1", "AQAAAAIAAYagAAAAEAuJ5+3CWEidsfrEcRaGiNsWsF90xRMicw3ASlnEPnzWXUFcV2MWLkp7bW2cWNYLkg==", "+9053399999991", true, "e26502c9-3f8f-4176-901c-a6d6ce546d03", false, "kullanici1" },
                    { 2, 0, "4258811d-a83f-46a6-9e55-1c8f76e515af", new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5559), "kullanici2@admin.com", true, "Kullanici2", "user2", false, null, "kullanici2@GMAIL.COM", "KULLANICI2", "AQAAAAIAAYagAAAAEOt0zh+jTHimeIecKvUFxch7nIzu7hfNvL5zZ6KrBloZo9RSpPWA8B///kSijIu0lg==", "+9053399999991", true, "297556d4-506e-46f8-8ade-24391906b311", false, "kullanici2" }
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
                    { 1, 1, false, new DateTime(2023, 7, 12, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4307), false, 100m, 1 },
                    { 2, 2, false, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4327), true, 100m, 2 },
                    { 3, 2, true, new DateTime(2023, 7, 9, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4328), true, 100m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "Name", "Price", "StockStatus" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4697), "Description 1", "Product 1", 9895m, true },
                    { 2, 2, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4706), "Description 2", "Product 2", 5079m, true },
                    { 3, 3, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4708), "Description 3", "Product 3", 3390m, true },
                    { 4, 4, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4710), "Description 4", "Product 4", 485m, true },
                    { 5, 5, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4711), "Description 5", "Product 5", 625m, true },
                    { 6, 6, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4714), "Description 6", "Product 6", 6033m, true },
                    { 7, 7, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4716), "Description 7", "Product 7", 2600m, true },
                    { 8, 8, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4717), "Description 8", "Product 8", 6717m, true },
                    { 9, 9, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4719), "Description 9", "Product 9", 8095m, true },
                    { 10, 10, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4721), "Description 10", "Product 10", 3716m, true },
                    { 11, 11, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4723), "Description 11", "Product 11", 3967m, true },
                    { 12, 12, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4724), "Description 12", "Product 12", 4489m, true },
                    { 13, 13, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4725), "Description 13", "Product 13", 379m, true },
                    { 14, 14, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4727), "Description 14", "Product 14", 535m, true },
                    { 15, 15, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4729), "Description 15", "Product 15", 3295m, true },
                    { 16, 16, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4730), "Description 16", "Product 16", 3681m, true },
                    { 17, 17, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4732), "Description 17", "Product 17", 9326m, true },
                    { 18, 18, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4951), "Description 18", "Product 18", 8234m, true },
                    { 19, 19, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4953), "Description 19", "Product 19", 5832m, true },
                    { 20, 20, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4955), "Description 20", "Product 20", 3288m, true },
                    { 21, 21, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4957), "Description 21", "Product 21", 9766m, true },
                    { 22, 22, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4958), "Description 22", "Product 22", 9430m, true },
                    { 23, 23, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4960), "Description 23", "Product 23", 4848m, true },
                    { 24, 24, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4962), "Description 24", "Product 24", 2662m, true },
                    { 25, 25, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4964), "Description 25", "Product 25", 2491m, true },
                    { 26, 26, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4966), "Description 26", "Product 26", 5233m, true },
                    { 27, 27, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4968), "Description 27", "Product 27", 9256m, true },
                    { 28, 28, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4969), "Description 28", "Product 28", 4785m, true },
                    { 29, 29, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4971), "Description 29", "Product 29", 3982m, true },
                    { 30, 30, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4973), "Description 30", "Product 30", 6895m, true },
                    { 31, 1, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4975), "Description 31", "Product 31", 2568m, true },
                    { 32, 2, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4976), "Description 32", "Product 32", 8211m, true },
                    { 33, 3, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4978), "Description 33", "Product 33", 9884m, true },
                    { 34, 4, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4981), "Description 34", "Product 34", 8703m, true },
                    { 35, 5, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4983), "Description 35", "Product 35", 9298m, true },
                    { 36, 6, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4984), "Description 36", "Product 36", 7104m, true },
                    { 37, 7, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4986), "Description 37", "Product 37", 9042m, true },
                    { 38, 8, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4987), "Description 38", "Product 38", 7211m, true },
                    { 39, 9, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4989), "Description 39", "Product 39", 3381m, true },
                    { 40, 10, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4991), "Description 40", "Product 40", 6985m, true },
                    { 41, 11, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4992), "Description 41", "Product 41", 1679m, true },
                    { 42, 12, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4994), "Description 42", "Product 42", 9258m, true },
                    { 43, 13, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4996), "Description 43", "Product 43", 4565m, true },
                    { 44, 14, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4997), "Description 44", "Product 44", 7544m, true },
                    { 45, 15, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(4999), "Description 45", "Product 45", 4756m, true },
                    { 46, 16, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5000), "Description 46", "Product 46", 9595m, true },
                    { 47, 17, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5002), "Description 47", "Product 47", 894m, true },
                    { 48, 18, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5003), "Description 48", "Product 48", 1336m, true },
                    { 49, 19, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5005), "Description 49", "Product 49", 2312m, true },
                    { 50, 20, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5006), "Description 50", "Product 50", 8818m, true },
                    { 51, 21, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5008), "Description 51", "Product 51", 2579m, true },
                    { 52, 22, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5010), "Description 52", "Product 52", 733m, true },
                    { 53, 23, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5011), "Description 53", "Product 53", 9252m, true },
                    { 54, 24, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5013), "Description 54", "Product 54", 6075m, true },
                    { 55, 25, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5015), "Description 55", "Product 55", 2371m, true },
                    { 56, 26, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5035), "Description 56", "Product 56", 8213m, true },
                    { 57, 27, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5038), "Description 57", "Product 57", 4363m, true },
                    { 58, 28, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5039), "Description 58", "Product 58", 3577m, true },
                    { 59, 29, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5041), "Description 59", "Product 59", 1147m, true },
                    { 60, 30, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5042), "Description 60", "Product 60", 8301m, true },
                    { 61, 1, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5044), "Description 61", "Product 61", 7329m, true },
                    { 62, 2, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5045), "Description 62", "Product 62", 6980m, true },
                    { 63, 3, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5047), "Description 63", "Product 63", 1282m, true },
                    { 64, 4, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5049), "Description 64", "Product 64", 4138m, true },
                    { 65, 5, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5050), "Description 65", "Product 65", 5776m, true },
                    { 66, 6, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5053), "Description 66", "Product 66", 2409m, true },
                    { 67, 7, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5055), "Description 67", "Product 67", 3519m, true },
                    { 68, 8, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5056), "Description 68", "Product 68", 6633m, true },
                    { 69, 9, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5058), "Description 69", "Product 69", 9166m, true },
                    { 70, 10, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5059), "Description 70", "Product 70", 2497m, true },
                    { 71, 11, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5061), "Description 71", "Product 71", 7165m, true },
                    { 72, 12, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5063), "Description 72", "Product 72", 7662m, true },
                    { 73, 13, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5064), "Description 73", "Product 73", 8921m, true },
                    { 74, 14, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5066), "Description 74", "Product 74", 4098m, true },
                    { 75, 15, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5068), "Description 75", "Product 75", 5810m, true },
                    { 76, 16, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5069), "Description 76", "Product 76", 6133m, true },
                    { 77, 17, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5071), "Description 77", "Product 77", 5665m, true },
                    { 78, 18, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5072), "Description 78", "Product 78", 1749m, true },
                    { 79, 19, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5074), "Description 79", "Product 79", 6214m, true },
                    { 80, 20, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5076), "Description 80", "Product 80", 3662m, true },
                    { 81, 21, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5077), "Description 81", "Product 81", 9436m, true },
                    { 82, 22, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5079), "Description 82", "Product 82", 8359m, true },
                    { 83, 23, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5080), "Description 83", "Product 83", 7131m, true },
                    { 84, 24, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5082), "Description 84", "Product 84", 6788m, true },
                    { 85, 25, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5083), "Description 85", "Product 85", 2254m, true },
                    { 86, 26, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5085), "Description 86", "Product 86", 7185m, true },
                    { 87, 27, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5086), "Description 87", "Product 87", 3502m, true },
                    { 88, 28, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5088), "Description 88", "Product 88", 1248m, true },
                    { 89, 29, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5090), "Description 89", "Product 89", 3065m, true },
                    { 90, 30, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5092), "Description 90", "Product 90", 8769m, true },
                    { 91, 1, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5093), "Description 91", "Product 91", 4394m, true },
                    { 92, 2, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5114), "Description 92", "Product 92", 2223m, true },
                    { 93, 3, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5116), "Description 93", "Product 93", 8941m, true },
                    { 94, 4, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5118), "Description 94", "Product 94", 2181m, true },
                    { 95, 5, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5119), "Description 95", "Product 95", 924m, true },
                    { 96, 6, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5121), "Description 96", "Product 96", 8708m, true },
                    { 97, 7, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5122), "Description 97", "Product 97", 8329m, true },
                    { 98, 8, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5124), "Description 98", "Product 98", 2561m, true },
                    { 99, 9, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5126), "Description 99", "Product 99", 295m, true },
                    { 100, 10, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5129), "Description 100", "Product 100", 1611m, true },
                    { 101, 11, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5131), "Description 101", "Product 101", 2523m, true },
                    { 102, 12, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5133), "Description 102", "Product 102", 8258m, true },
                    { 103, 13, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5134), "Description 103", "Product 103", 4730m, true },
                    { 104, 14, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5136), "Description 104", "Product 104", 8148m, true },
                    { 105, 15, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5137), "Description 105", "Product 105", 4768m, true },
                    { 106, 16, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5139), "Description 106", "Product 106", 3645m, true },
                    { 107, 17, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5141), "Description 107", "Product 107", 7325m, true },
                    { 108, 18, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5143), "Description 108", "Product 108", 1904m, true },
                    { 109, 19, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5144), "Description 109", "Product 109", 9953m, true },
                    { 110, 20, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5146), "Description 110", "Product 110", 8038m, true },
                    { 111, 21, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5147), "Description 111", "Product 111", 9814m, true },
                    { 112, 22, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5149), "Description 112", "Product 112", 9831m, true },
                    { 113, 23, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5150), "Description 113", "Product 113", 9076m, true },
                    { 114, 24, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5152), "Description 114", "Product 114", 8570m, true },
                    { 115, 25, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5154), "Description 115", "Product 115", 2857m, true },
                    { 116, 26, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5155), "Description 116", "Product 116", 3738m, true },
                    { 117, 27, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5157), "Description 117", "Product 117", 574m, true },
                    { 118, 28, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5158), "Description 118", "Product 118", 4605m, true },
                    { 119, 29, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5160), "Description 119", "Product 119", 5209m, true },
                    { 120, 30, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5162), "Description 120", "Product 120", 7709m, true },
                    { 121, 1, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5163), "Description 121", "Product 121", 6337m, true },
                    { 122, 2, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5165), "Description 122", "Product 122", 2544m, true },
                    { 123, 3, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5166), "Description 123", "Product 123", 6006m, true },
                    { 124, 4, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5168), "Description 124", "Product 124", 3712m, true },
                    { 125, 5, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5170), "Description 125", "Product 125", 8827m, true },
                    { 126, 6, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5171), "Description 126", "Product 126", 3788m, true },
                    { 127, 7, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5173), "Description 127", "Product 127", 9017m, true },
                    { 128, 8, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5175), "Description 128", "Product 128", 699m, true },
                    { 129, 9, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5176), "Description 129", "Product 129", 712m, true },
                    { 130, 10, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5200), "Description 130", "Product 130", 3469m, true },
                    { 131, 11, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5202), "Description 131", "Product 131", 51m, true },
                    { 132, 12, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5204), "Description 132", "Product 132", 8552m, true },
                    { 133, 13, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5205), "Description 133", "Product 133", 1099m, true },
                    { 134, 14, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5207), "Description 134", "Product 134", 7554m, true },
                    { 135, 15, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5208), "Description 135", "Product 135", 8092m, true },
                    { 136, 16, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5210), "Description 136", "Product 136", 2739m, true },
                    { 137, 17, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5212), "Description 137", "Product 137", 1123m, true },
                    { 138, 18, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5213), "Description 138", "Product 138", 3137m, true },
                    { 139, 19, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5215), "Description 139", "Product 139", 5139m, true },
                    { 140, 20, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5216), "Description 140", "Product 140", 569m, true },
                    { 141, 21, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5218), "Description 141", "Product 141", 3534m, true },
                    { 142, 22, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5220), "Description 142", "Product 142", 6428m, true },
                    { 143, 23, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5221), "Description 143", "Product 143", 6654m, true },
                    { 144, 24, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5223), "Description 144", "Product 144", 2269m, true },
                    { 145, 25, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5225), "Description 145", "Product 145", 1967m, true },
                    { 146, 26, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5226), "Description 146", "Product 146", 4227m, true },
                    { 147, 27, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5228), "Description 147", "Product 147", 3231m, true },
                    { 148, 28, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5229), "Description 148", "Product 148", 7294m, true },
                    { 149, 29, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5231), "Description 149", "Product 149", 1583m, true },
                    { 150, 30, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5232), "Description 150", "Product 150", 3402m, true },
                    { 151, 1, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5234), "Description 151", "Product 151", 7128m, true },
                    { 152, 2, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5236), "Description 152", "Product 152", 1768m, true },
                    { 153, 3, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5238), "Description 153", "Product 153", 3824m, true },
                    { 154, 4, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5239), "Description 154", "Product 154", 8960m, true },
                    { 155, 5, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5241), "Description 155", "Product 155", 7217m, true },
                    { 156, 6, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5242), "Description 156", "Product 156", 9267m, true },
                    { 157, 7, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5244), "Description 157", "Product 157", 8051m, true },
                    { 158, 8, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5246), "Description 158", "Product 158", 3965m, true },
                    { 159, 9, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5247), "Description 159", "Product 159", 5399m, true },
                    { 160, 10, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5249), "Description 160", "Product 160", 6785m, true },
                    { 161, 11, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5250), "Description 161", "Product 161", 2013m, true },
                    { 162, 12, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5252), "Description 162", "Product 162", 5039m, true },
                    { 163, 13, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5274), "Description 163", "Product 163", 9739m, true },
                    { 164, 14, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5276), "Description 164", "Product 164", 7162m, true },
                    { 165, 15, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5278), "Description 165", "Product 165", 6922m, true },
                    { 166, 16, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5280), "Description 166", "Product 166", 3934m, true },
                    { 167, 17, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5282), "Description 167", "Product 167", 2778m, true },
                    { 168, 18, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5283), "Description 168", "Product 168", 3043m, true },
                    { 169, 19, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5285), "Description 169", "Product 169", 8095m, true },
                    { 170, 20, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5286), "Description 170", "Product 170", 5762m, true },
                    { 171, 21, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5288), "Description 171", "Product 171", 2151m, true },
                    { 172, 22, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5289), "Description 172", "Product 172", 9992m, true },
                    { 173, 23, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5291), "Description 173", "Product 173", 9933m, true },
                    { 174, 24, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5293), "Description 174", "Product 174", 5866m, true },
                    { 175, 25, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5295), "Description 175", "Product 175", 1759m, true },
                    { 176, 26, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5297), "Description 176", "Product 176", 5139m, true },
                    { 177, 27, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5298), "Description 177", "Product 177", 1153m, true },
                    { 178, 28, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5300), "Description 178", "Product 178", 9750m, true },
                    { 179, 29, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5302), "Description 179", "Product 179", 6915m, true },
                    { 180, 30, new DateTime(2023, 7, 14, 17, 4, 55, 278, DateTimeKind.Local).AddTicks(5304), "Description 180", "Product 180", 1396m, true }
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
