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
                    { 1, 0, "c0fd9dee-9e45-439a-baf2-d8b8f59b1ed8", new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(9161), "kullanici1@admin.com", true, "Kullanici1", "user1", false, null, "kullanici1@GMAIL.COM", "KULLANICI1", "AQAAAAIAAYagAAAAEKgpOfT/D7IGn2nMUCn7yjztEAX3R0evkMO4w+mq9CiysLVOoLsoitpAvpIDermb0w==", "+9053399999991", true, "8f378276-8ac3-41fb-91d3-e1eafdda3a65", false, "kullanici1" },
                    { 2, 0, "c93c33c2-7d07-4e10-a4e0-558a0f44d92d", new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(9169), "kullanici2@admin.com", true, "Kullanici2", "user2", false, null, "kullanici2@GMAIL.COM", "KULLANICI2", "AQAAAAIAAYagAAAAEIiYQvk1ytmlrsRYh0AjB7jHh/gMopJBZKqOW2/RwmnWjDgY+z/C3yZkf/STlkYS0A==", "+9053399999991", true, "b35760c5-3bd9-46d5-84bc-aa711450613f", false, "kullanici2" }
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
                    { 1, false, new DateTime(2023, 7, 13, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8041), false, 100m, 1 },
                    { 2, false, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8061), true, 100m, 2 },
                    { 3, true, new DateTime(2023, 7, 10, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8063), true, 100m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "Name", "Price", "StockStatus" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8370), "Description 1", "Product 1", 8819m, true },
                    { 2, 2, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8402), "Description 2", "Product 2", 5154m, true },
                    { 3, 3, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8404), "Description 3", "Product 3", 8083m, true },
                    { 4, 4, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8405), "Description 4", "Product 4", 450m, true },
                    { 5, 5, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8407), "Description 5", "Product 5", 9886m, true },
                    { 6, 6, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8409), "Description 6", "Product 6", 4383m, true },
                    { 7, 7, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8411), "Description 7", "Product 7", 2407m, true },
                    { 8, 8, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8412), "Description 8", "Product 8", 7900m, true },
                    { 9, 9, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8414), "Description 9", "Product 9", 1682m, true },
                    { 10, 10, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8416), "Description 10", "Product 10", 1653m, true },
                    { 11, 11, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8418), "Description 11", "Product 11", 2029m, true },
                    { 12, 12, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8419), "Description 12", "Product 12", 9874m, true },
                    { 13, 13, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8421), "Description 13", "Product 13", 8793m, true },
                    { 14, 14, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8422), "Description 14", "Product 14", 7337m, true },
                    { 15, 15, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8423), "Description 15", "Product 15", 2752m, true },
                    { 16, 16, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8425), "Description 16", "Product 16", 157m, true },
                    { 17, 17, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8426), "Description 17", "Product 17", 7283m, true },
                    { 18, 18, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8429), "Description 18", "Product 18", 9347m, true },
                    { 19, 19, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8430), "Description 19", "Product 19", 3479m, true },
                    { 20, 20, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8432), "Description 20", "Product 20", 4552m, true },
                    { 21, 21, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8433), "Description 21", "Product 21", 4325m, true },
                    { 22, 22, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8435), "Description 22", "Product 22", 2279m, true },
                    { 23, 23, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8436), "Description 23", "Product 23", 1182m, true },
                    { 24, 24, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8438), "Description 24", "Product 24", 7573m, true },
                    { 25, 25, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8440), "Description 25", "Product 25", 6611m, true },
                    { 26, 26, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8441), "Description 26", "Product 26", 9121m, true },
                    { 27, 27, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8443), "Description 27", "Product 27", 5540m, true },
                    { 28, 28, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8444), "Description 28", "Product 28", 1114m, true },
                    { 29, 29, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8445), "Description 29", "Product 29", 6305m, true },
                    { 30, 30, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8447), "Description 30", "Product 30", 6731m, true },
                    { 31, 1, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8448), "Description 31", "Product 31", 7719m, true },
                    { 32, 2, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8450), "Description 32", "Product 32", 5157m, true },
                    { 33, 3, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8451), "Description 33", "Product 33", 9206m, true },
                    { 34, 4, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8454), "Description 34", "Product 34", 3469m, true },
                    { 35, 5, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8455), "Description 35", "Product 35", 1408m, true },
                    { 36, 6, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8457), "Description 36", "Product 36", 8628m, true },
                    { 37, 7, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8458), "Description 37", "Product 37", 8300m, true },
                    { 38, 8, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8480), "Description 38", "Product 38", 4367m, true },
                    { 39, 9, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8482), "Description 39", "Product 39", 4275m, true },
                    { 40, 10, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8484), "Description 40", "Product 40", 8155m, true },
                    { 41, 11, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8486), "Description 41", "Product 41", 5005m, true },
                    { 42, 12, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8487), "Description 42", "Product 42", 3293m, true },
                    { 43, 13, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8488), "Description 43", "Product 43", 8192m, true },
                    { 44, 14, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8490), "Description 44", "Product 44", 9453m, true },
                    { 45, 15, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8491), "Description 45", "Product 45", 7405m, true },
                    { 46, 16, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8493), "Description 46", "Product 46", 7146m, true },
                    { 47, 17, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8494), "Description 47", "Product 47", 766m, true },
                    { 48, 18, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8496), "Description 48", "Product 48", 5787m, true },
                    { 49, 19, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8497), "Description 49", "Product 49", 1486m, true },
                    { 50, 20, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8499), "Description 50", "Product 50", 5046m, true },
                    { 51, 21, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8500), "Description 51", "Product 51", 5878m, true },
                    { 52, 22, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8502), "Description 52", "Product 52", 1029m, true },
                    { 53, 23, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8503), "Description 53", "Product 53", 8283m, true },
                    { 54, 24, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8505), "Description 54", "Product 54", 751m, true },
                    { 55, 25, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8506), "Description 55", "Product 55", 6986m, true },
                    { 56, 26, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8507), "Description 56", "Product 56", 290m, true },
                    { 57, 27, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8509), "Description 57", "Product 57", 2168m, true },
                    { 58, 28, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8510), "Description 58", "Product 58", 4208m, true },
                    { 59, 29, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8512), "Description 59", "Product 59", 3561m, true },
                    { 60, 30, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8513), "Description 60", "Product 60", 9894m, true },
                    { 61, 1, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8514), "Description 61", "Product 61", 4302m, true },
                    { 62, 2, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8516), "Description 62", "Product 62", 5373m, true },
                    { 63, 3, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8517), "Description 63", "Product 63", 4969m, true },
                    { 64, 4, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8518), "Description 64", "Product 64", 9111m, true },
                    { 65, 5, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8520), "Description 65", "Product 65", 7599m, true },
                    { 66, 6, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8522), "Description 66", "Product 66", 8573m, true },
                    { 67, 7, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8523), "Description 67", "Product 67", 1721m, true },
                    { 68, 8, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8525), "Description 68", "Product 68", 6732m, true },
                    { 69, 9, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8526), "Description 69", "Product 69", 7061m, true },
                    { 70, 10, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8528), "Description 70", "Product 70", 3159m, true },
                    { 71, 11, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8529), "Description 71", "Product 71", 3653m, true },
                    { 72, 12, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8530), "Description 72", "Product 72", 1042m, true },
                    { 73, 13, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8532), "Description 73", "Product 73", 1107m, true },
                    { 74, 14, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8553), "Description 74", "Product 74", 7610m, true },
                    { 75, 15, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8555), "Description 75", "Product 75", 4738m, true },
                    { 76, 16, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8557), "Description 76", "Product 76", 4976m, true },
                    { 77, 17, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8558), "Description 77", "Product 77", 7304m, true },
                    { 78, 18, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8560), "Description 78", "Product 78", 6433m, true },
                    { 79, 19, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8562), "Description 79", "Product 79", 5362m, true },
                    { 80, 20, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8563), "Description 80", "Product 80", 9322m, true },
                    { 81, 21, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8564), "Description 81", "Product 81", 3288m, true },
                    { 82, 22, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8566), "Description 82", "Product 82", 3079m, true },
                    { 83, 23, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8568), "Description 83", "Product 83", 6254m, true },
                    { 84, 24, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8569), "Description 84", "Product 84", 7709m, true },
                    { 85, 25, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8571), "Description 85", "Product 85", 4804m, true },
                    { 86, 26, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8572), "Description 86", "Product 86", 8817m, true },
                    { 87, 27, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8573), "Description 87", "Product 87", 9754m, true },
                    { 88, 28, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8575), "Description 88", "Product 88", 6629m, true },
                    { 89, 29, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8577), "Description 89", "Product 89", 4635m, true },
                    { 90, 30, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8578), "Description 90", "Product 90", 6745m, true },
                    { 91, 1, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8579), "Description 91", "Product 91", 1588m, true },
                    { 92, 2, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8581), "Description 92", "Product 92", 3731m, true },
                    { 93, 3, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8582), "Description 93", "Product 93", 4113m, true },
                    { 94, 4, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8584), "Description 94", "Product 94", 6545m, true },
                    { 95, 5, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8585), "Description 95", "Product 95", 9979m, true },
                    { 96, 6, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8586), "Description 96", "Product 96", 385m, true },
                    { 97, 7, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8588), "Description 97", "Product 97", 6284m, true },
                    { 98, 8, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8589), "Description 98", "Product 98", 1905m, true },
                    { 99, 9, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8591), "Description 99", "Product 99", 3874m, true },
                    { 100, 10, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8592), "Description 100", "Product 100", 7761m, true },
                    { 101, 11, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8594), "Description 101", "Product 101", 9814m, true },
                    { 102, 12, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8595), "Description 102", "Product 102", 6120m, true },
                    { 103, 13, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8597), "Description 103", "Product 103", 7362m, true },
                    { 104, 14, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8598), "Description 104", "Product 104", 5440m, true },
                    { 105, 15, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8600), "Description 105", "Product 105", 6032m, true },
                    { 106, 16, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8601), "Description 106", "Product 106", 1318m, true },
                    { 107, 17, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8603), "Description 107", "Product 107", 7456m, true },
                    { 108, 18, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8605), "Description 108", "Product 108", 9254m, true },
                    { 109, 19, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8606), "Description 109", "Product 109", 4110m, true },
                    { 110, 20, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8608), "Description 110", "Product 110", 1502m, true },
                    { 111, 21, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8610), "Description 111", "Product 111", 7394m, true },
                    { 112, 22, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8611), "Description 112", "Product 112", 494m, true },
                    { 113, 23, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8613), "Description 113", "Product 113", 6096m, true },
                    { 114, 24, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8614), "Description 114", "Product 114", 1219m, true },
                    { 115, 25, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8646), "Description 115", "Product 115", 3456m, true },
                    { 116, 26, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8648), "Description 116", "Product 116", 8395m, true },
                    { 117, 27, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8650), "Description 117", "Product 117", 7828m, true },
                    { 118, 28, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8651), "Description 118", "Product 118", 884m, true },
                    { 119, 29, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8653), "Description 119", "Product 119", 8613m, true },
                    { 120, 30, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8654), "Description 120", "Product 120", 5210m, true },
                    { 121, 1, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8656), "Description 121", "Product 121", 4724m, true },
                    { 122, 2, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8657), "Description 122", "Product 122", 7009m, true },
                    { 123, 3, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8659), "Description 123", "Product 123", 9532m, true },
                    { 124, 4, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8660), "Description 124", "Product 124", 9930m, true },
                    { 125, 5, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8662), "Description 125", "Product 125", 3307m, true },
                    { 126, 6, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8663), "Description 126", "Product 126", 5358m, true },
                    { 127, 7, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8665), "Description 127", "Product 127", 5314m, true },
                    { 128, 8, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8667), "Description 128", "Product 128", 2767m, true },
                    { 129, 9, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8668), "Description 129", "Product 129", 8532m, true },
                    { 130, 10, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8671), "Description 130", "Product 130", 2441m, true },
                    { 131, 11, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8672), "Description 131", "Product 131", 899m, true },
                    { 132, 12, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8674), "Description 132", "Product 132", 2838m, true },
                    { 133, 13, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8675), "Description 133", "Product 133", 7062m, true },
                    { 134, 14, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8677), "Description 134", "Product 134", 8303m, true },
                    { 135, 15, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8678), "Description 135", "Product 135", 5568m, true },
                    { 136, 16, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8680), "Description 136", "Product 136", 2325m, true },
                    { 137, 17, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8681), "Description 137", "Product 137", 8838m, true },
                    { 138, 18, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8683), "Description 138", "Product 138", 5753m, true },
                    { 139, 19, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8684), "Description 139", "Product 139", 5507m, true },
                    { 140, 20, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8686), "Description 140", "Product 140", 9275m, true },
                    { 141, 21, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8687), "Description 141", "Product 141", 8860m, true },
                    { 142, 22, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8689), "Description 142", "Product 142", 3844m, true },
                    { 143, 23, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8690), "Description 143", "Product 143", 618m, true },
                    { 144, 24, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8692), "Description 144", "Product 144", 482m, true },
                    { 145, 25, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8712), "Description 145", "Product 145", 4821m, true },
                    { 146, 26, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8714), "Description 146", "Product 146", 5882m, true },
                    { 147, 27, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8716), "Description 147", "Product 147", 759m, true },
                    { 148, 28, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8717), "Description 148", "Product 148", 5153m, true },
                    { 149, 29, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8719), "Description 149", "Product 149", 7836m, true },
                    { 150, 30, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8720), "Description 150", "Product 150", 3631m, true },
                    { 151, 1, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8722), "Description 151", "Product 151", 4404m, true },
                    { 152, 2, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8723), "Description 152", "Product 152", 8492m, true },
                    { 153, 3, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8725), "Description 153", "Product 153", 3894m, true },
                    { 154, 4, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8727), "Description 154", "Product 154", 8425m, true },
                    { 155, 5, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8728), "Description 155", "Product 155", 7852m, true },
                    { 156, 6, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8730), "Description 156", "Product 156", 3971m, true },
                    { 157, 7, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8731), "Description 157", "Product 157", 2365m, true },
                    { 158, 8, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8733), "Description 158", "Product 158", 2849m, true },
                    { 159, 9, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8734), "Description 159", "Product 159", 6054m, true },
                    { 160, 10, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8736), "Description 160", "Product 160", 2838m, true },
                    { 161, 11, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8738), "Description 161", "Product 161", 9892m, true },
                    { 162, 12, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8739), "Description 162", "Product 162", 9591m, true },
                    { 163, 13, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8741), "Description 163", "Product 163", 2558m, true },
                    { 164, 14, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8743), "Description 164", "Product 164", 5829m, true },
                    { 165, 15, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8744), "Description 165", "Product 165", 1245m, true },
                    { 166, 16, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8746), "Description 166", "Product 166", 8951m, true },
                    { 167, 17, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8747), "Description 167", "Product 167", 3521m, true },
                    { 168, 18, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8749), "Description 168", "Product 168", 9688m, true },
                    { 169, 19, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8750), "Description 169", "Product 169", 4802m, true },
                    { 170, 20, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8751), "Description 170", "Product 170", 4153m, true },
                    { 171, 21, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8753), "Description 171", "Product 171", 4385m, true },
                    { 172, 22, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8754), "Description 172", "Product 172", 9329m, true },
                    { 173, 23, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8756), "Description 173", "Product 173", 405m, true },
                    { 174, 24, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8757), "Description 174", "Product 174", 7573m, true },
                    { 175, 25, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8759), "Description 175", "Product 175", 1505m, true },
                    { 176, 26, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8760), "Description 176", "Product 176", 2609m, true },
                    { 177, 27, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8762), "Description 177", "Product 177", 3545m, true },
                    { 178, 28, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8763), "Description 178", "Product 178", 9123m, true },
                    { 179, 29, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8765), "Description 179", "Product 179", 708m, true },
                    { 180, 30, new DateTime(2023, 7, 15, 19, 25, 17, 562, DateTimeKind.Local).AddTicks(8766), "Description 180", "Product 180", 6807m, true }
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
