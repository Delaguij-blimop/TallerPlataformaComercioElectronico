using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallerPlataformaComercioElectronico.Migrations
{
    public partial class initialDBCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FraudReport = table.Column<bool>(type: "bit", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: true),
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
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CodigoISO = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CardHolderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CVV = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m),
                    BillingAddressId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Addresses_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FraudReport", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "46d62ce6-0f46-4c8e-b863-bfbdee69f58f", 0, "073c407b-dcd0-4039-b2ad-1059ede19e7e", "ApplicationUser", "admin@carrito.com.ar", false, false, true, false, null, "ADMIN@CARRITO.COM.AR", "ADMIN@CARRITO.COM.AR", "AQAAAAEAACcQAAAAEBqKOI75zr0oD8Th8AJyDyEDbV+twvrleq/c/5SczRD+vY2y6ghxghAtNWEWZqg3tw==", null, false, "CRNRUGJ7ALBDPBKP6ZTBSL3Q2R7A25YV", false, "admin@carrito.com.ar" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Description", "RegisterDate" },
                values: new object[,]
                {
                    { 1, "SONY", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, "HP", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, "LG", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4, "HYUNDAI", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 5, "CANON", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 6, "ROBERTA ALLEN", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 7, "MICA", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 8, "FORLI", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 9, "BE CRAFTY", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 10, "ADIDAS", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 11, "BEST", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 12, "REEBOK", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 13, "FOSSIL", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 14, "BILLABONG", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 15, "POWCO", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 16, "HOT WHEELS", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 17, "LEGO", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 18, "SAMSUNG", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 19, "RECCO", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 20, "INDURAMA", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 21, "ALFANO", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 22, "MABE", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 23, "ELECTROLUX", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "RegisterDate" },
                values: new object[,]
                {
                    { 1, "Tecnología", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, "Muebles", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, "Dormitorio", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4, "Deportes", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 5, "Zapatos", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 6, "Accesorios", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 7, "Juguetería", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 8, "Electrohogar", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Description", "RegisterDate" },
                values: new object[] { 1, "Argentina", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "CodigoISO", "Description", "RegisterDate" },
                values: new object[,]
                {
                    { 1, "ARS", "Peso Argentino", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, "USD", "Dolar", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Description", "ImagePath", "RegisterDate" },
                values: new object[,]
                {
                    { 1, "Tarjeta de Crédito", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\PaymentMethods\\CreditCardIcon.png", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, "PayPal", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\PaymentMethods\\PayPalIcon.jpg", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "Description", "ImagePath", "Price", "RegisterDate", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 1, "Consola de PS4 Pro 1TB Negro", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\Products\\1.jpg", 2000m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 50 },
                    { 2, 2, 1, "HP Laptop 15-EF1019LA", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\Products\\2.jpg", 2500m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 60 },
                    { 3, 3, 1, "Televisor 65 4K Ultra HD Smart 65UN710", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\Products\\3.jpg", 3000m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 120 },
                    { 4, 4, 1, "Televisor 50 4K Ultra HD Smart Android", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\Products\\4.jpg", 3200m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 70 },
                    { 5, 5, 1, "Cámara Reflex EOS Rebel T100", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\Products\\5.jpg", 1560m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 90 },
                    { 6, 6, 2, "Aparador Surat", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\Products\\6.jpg", 500m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 60 },
                    { 7, 7, 2, "Mesa de Comedor Donatello", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\Products\\7.jpg", 400m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 90 },
                    { 8, 8, 3, "Colchón Polaris 1 Plz + 1 Almohada", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\Products\\8.jpg", 500m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 120 },
                    { 9, 6, 3, "Juegos de Sábanas 180 Hilos Solid", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\Products\\9.jpg", 200m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 130 },
                    { 10, 7, 3, "Tocador Franca", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\Products\\10.jpg", 450m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 60 },
                    { 11, 9, 3, "Alfombra Infantil de Osa Melange", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\Products\\11.jpg", 120m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 50 },
                    { 12, 10, 4, "Mochila Unisex Deportivo Classic", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\Products\\12.jpg", 220m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 45 },
                    { 13, 11, 4, "Bicicleta de Montaña Best Inka 29 Roja", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\Products\\13.jpg", 890m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 75 },
                    { 14, 10, 5, "Zapatillas Urbanas Mujer adidas", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\Products\\14.jpg", 260m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 80 },
                    { 15, 12, 5, "Zapatillas Training Hombre Rebook", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\Products\\15.jpg", 230m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 38 },
                    { 16, 13, 6, "Reloj", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\Products\\16.jpg", 300m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 20 },
                    { 17, 14, 6, "Billetera Hombre", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\Products\\17.jpg", 87m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 88 },
                    { 18, 15, 7, "Auto Deportivo 45 cm Naranja", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\Products\\18.jpg", 90m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 55 },
                    { 19, 16, 7, "Set de Juego Hot Wheels", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\Products\\19.jpg", 130m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 70 },
                    { 20, 17, 7, "Set Lego Classic: Maletín Creativo", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\Products\\20.jpg", 110m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 60 },
                    { 21, 18, 8, "Refrigerador Samsung 295 litros", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\Products\\21.jpg", 2100m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 90 },
                    { 22, 19, 8, "Ventilador 3 En 1", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\Products\\22.jpg", 1100m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 56 },
                    { 23, 20, 8, "Frigobar 92 Lt Blanco", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\Products\\23.jpg", 940m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 78 },
                    { 24, 21, 8, "Aire Acondicionado Split", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\Products\\24.jpg", 1700m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 56 },
                    { 25, 22, 8, "Lavadora Mabe 16kg", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\Products\\25.jpg", 2800m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 48 },
                    { 26, 23, 8, "Campana Extractora EJSE202", "C:\\Users\\eblim\\source\\repos\\TallerPlataformaComercioElectronico\\TallerPlataformaComercioElectronico\\wwwroot\\Images\\Products\\26.jpg", 1500m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 56 }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CountryId", "Description", "RegisterDate" },
                values: new object[,]
                {
                    { 1, 1, "Buenos Aires", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 1, "Catamarca", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, 1, "Chaco", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4, 1, "Chubut", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 5, 1, "Córdoba", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 6, 1, "Corrientes", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 7, 1, "Entre Ríos", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 8, 1, "Formosa", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 9, 1, "Jujuy", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 10, 1, "La Pampa", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 11, 1, "La Rioja", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 12, 1, "Mendoza", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 13, 1, "Misiones", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 14, 1, "Neuquén", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 15, 1, "Río Negro", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 16, 1, "Salta", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CountryId", "Description", "RegisterDate" },
                values: new object[,]
                {
                    { 17, 1, "San Juan", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 18, 1, "San Luis", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 19, 1, "Santa Cruz", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 20, 1, "Santa Fe", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 21, 1, "Santiago del Estero", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 22, 1, "Tierra del Fuego", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 23, 1, "Tucumán", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 24, 1, "Ciudad Autónoma de Buenos Aires", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Description", "RegisterDate", "StateId" },
                values: new object[,]
                {
                    { 1, "La Plata", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 2, "Mar del Plata", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 3, "San Fernando del Valle de Catamarca", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 4, "Belén", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 5, "Resistencia", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 3 },
                    { 6, "Presidencia Roque Sáenz Peña", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 3 },
                    { 7, "Rawson", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 4 },
                    { 8, "Comodoro Rivadavia", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 4 },
                    { 9, "Córdoba", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 5 },
                    { 10, "Villa Carlos Paz", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 5 },
                    { 11, "Corrientes", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 6 },
                    { 12, "Goya", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 6 },
                    { 13, "Paraná", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 7 },
                    { 14, "Concordia", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 7 },
                    { 15, "Formosa", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 8 },
                    { 16, "Clorinda", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 8 },
                    { 17, "San Salvador de Jujuy", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 9 },
                    { 18, "Palpalá", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 9 },
                    { 19, "Santa Rosa", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 10 },
                    { 20, "General Pico", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 10 },
                    { 21, "La Rioja", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 11 },
                    { 22, "Chilecito", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 11 },
                    { 23, "Mendoza", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 12 },
                    { 24, "San Rafael", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 12 },
                    { 25, "Posadas", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 13 },
                    { 26, "Oberá", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 13 },
                    { 27, "Neuquén", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 14 },
                    { 28, "San Martín de los Andes", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 14 },
                    { 29, "Viedma", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 15 },
                    { 30, "San Carlos de Bariloche", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 15 },
                    { 31, "Salta", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 16 },
                    { 32, "Tartagal", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 16 },
                    { 33, "San Juan", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 17 },
                    { 34, "Caucete", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 17 },
                    { 35, "San Luis", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 18 },
                    { 36, "Villa Mercedes", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 18 },
                    { 37, "Río Gallegos", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 19 },
                    { 38, "Caleta Olivia", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 19 },
                    { 39, "Santa Fe", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 20 },
                    { 40, "Rosario", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 20 },
                    { 41, "Santiago del Estero", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 21 },
                    { 42, "La Banda", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 21 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Description", "RegisterDate", "StateId" },
                values: new object[,]
                {
                    { 43, "Ushuaia", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 22 },
                    { 44, "Río Grande", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 22 },
                    { 45, "San Miguel de Tucumán", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 23 },
                    { 46, "Tafí Viejo", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 23 },
                    { 47, "Buenos Aires", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local), 24 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

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
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CurrencyId",
                table: "Orders",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BillingAddressId",
                table: "Payments",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentMethodId",
                table: "Payments",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_OrderId",
                table: "ShoppingCarts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ProductId",
                table: "ShoppingCarts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
