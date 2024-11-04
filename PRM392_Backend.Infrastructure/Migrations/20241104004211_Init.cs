using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PRM392_Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
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
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
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
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.ID);
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChatMessages_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreLocations",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreLocations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StoreLocations_Stores_StoreID",
                        column: x => x.StoreID,
                        principalTable: "Stores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BillingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CartID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StoreLocationID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Carts_CartID",
                        column: x => x.CartID,
                        principalTable: "Carts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_StoreLocations_StoreLocationID",
                        column: x => x.StoreLocationID,
                        principalTable: "StoreLocations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BriefDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FullDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnicalSpecification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Products_Stores_StoreID",
                        column: x => x.StoreID,
                        principalTable: "Stores",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartID",
                        column: x => x.CartID,
                        principalTable: "Carts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3cb28e4f-3fd1-434b-9935-779228be461d", null, "Admin", "ADMIN" },
                    { "fca9741b-e4c7-4597-9a82-0f2f9621e747", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CategoryName", "ImageUrl", "IsActive" },
                values: new object[,]
                {
                    { new Guid("2d85ef10-9237-46e8-8131-955eb56c27f0"), "Pizzas", "https://firebasestorage.googleapis.com/v0/b/deliveroo-dab94.appspot.com/o/Splash%2Fpizza.jpg?alt=media&token=ae5cf452-4184-4b20-9f39-c1a49ca5b975", true },
                    { new Guid("5a2834d9-2630-4d1f-8126-daa29b800e78"), "Burgers", "https://firebasestorage.googleapis.com/v0/b/deliveroo-dab94.appspot.com/o/Splash%2Fburger.jpg?alt=media&token=4913b4f4-b37f-44a6-9fae-48beec255483", true },
                    { new Guid("804563c3-05f3-4997-98fd-b23e4a310fb6"), "Italian", "https://firebasestorage.googleapis.com/v0/b/deliveroo-dab94.appspot.com/o/Splash%2Fmiy.jpg?alt=media&token=dc0800c8-8415-4c2b-90f1-8e26756dc469", true },
                    { new Guid("82de5b3d-ca35-420d-8e98-cc432b510201"), "Sushi", "https://firebasestorage.googleapis.com/v0/b/deliveroo-dab94.appspot.com/o/Splash%2Fsushi.jpg?alt=media&token=c86cb412-e217-4f71-a64e-c6e17bc3d6c6", true },
                    { new Guid("beffabc8-6f9f-4d08-b69a-8cb5226e8486"), "Chinese", "https://firebasestorage.googleapis.com/v0/b/deliveroo-dab94.appspot.com/o/Splash%2Fchinese.jpg?alt=media&token=84155e4f-4949-4846-927a-5f0d7c08ed7b", true }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "BriefDescription", "CategoryId", "FullDescription", "ImageURL", "IsActive", "OrderID", "Price", "ProductName", "StoreID", "TechnicalSpecification" },
                values: new object[,]
                {
                    { new Guid("067e22e7-1d7d-43e9-927e-63aad59be917"), "A refreshing blend of ripe mango, coconut milk, and pineapple for a tropical escape in a glass.", new Guid("82de5b3d-ca35-420d-8e98-cc432b510201"), "The Tropical Mango Smoothie is a vibrant and refreshing drink that brings the taste of the tropics to your table. This smoothie is made with ripe mangoes, sweet pineapple chunks, and creamy coconut milk, blended to a silky smooth consistency. It’s naturally sweet and packed with vitamins, offering a deliciously healthy way to cool down on a warm day. The hint of lime juice adds a refreshing citrus kick, making this smoothie both energizing and satisfying.", "https://prm392.blob.core.windows.net/prm392/TropicalMangoSmoothie.jpg", true, null, 2.9900000000000002, "Tropical Mango Smoothie", null, "Fresh mango, pineapple, coconut milk, lime juice, ice" },
                    { new Guid("08a7cf22-90a7-4823-9fe6-4264d3ee0a87"), "A classic pizza with tomato sauce, mozzarella cheese, and fresh basil leaves.", new Guid("2d85ef10-9237-46e8-8131-955eb56c27f0"), "The Margherita Pizza is a timeless classic that never goes out of style. It features a thin, crispy crust topped with tangy tomato sauce, creamy mozzarella cheese, and fragrant basil leaves. Each bite offers a burst of fresh flavors and a perfect balance of textures, making it a favorite among pizza lovers. Whether you're a fan of traditional recipes or simply appreciate the simplicity of good ingredients, this pizza is sure to satisfy your cravings.", "https://prm392.blob.core.windows.net/prm392/MargheritaPizza.jpg", true, null, 10.99, "Margherita Pizza", null, "Tomato sauce, mozzarella cheese, basil leaves" },
                    { new Guid("09fdd4f0-74d9-498b-9026-56237a7573f3"), "A refreshing tea drink with a hint of lemon and sweetened with sugar.", new Guid("82de5b3d-ca35-420d-8e98-cc432b510201"), "The Iced Tea is a classic beverage that offers a cool and refreshing taste, perfect for hot summer days or as a thirst-quenching treat. Made from brewed tea leaves, sweetened with sugar, and flavored with a hint of lemon, this drink is both invigorating and satisfying. Whether you're looking for a caffeine-free alternative to soda or simply enjoy the taste of tea, this iced tea is sure to hit the spot.", "https://prm392.blob.core.windows.net/prm392/IcedTea.jpg", true, null, 2.9900000000000002, "Iced Tea", null, "Brewed tea leaves, sugar, lemon flavor" },
                    { new Guid("13298515-27ac-4116-8394-81f6deaa4585"), "Grilled chicken breast on a bed of mixed greens, cherry tomatoes, cucumbers, and balsamic vinaigrette.", new Guid("beffabc8-6f9f-4d08-b69a-8cb5226e8486"), "The Grilled Chicken Salad is a fresh and healthy option that offers a perfect balance of flavors and textures. It features a juicy grilled chicken breast on a bed of crisp mixed greens, cherry tomatoes, and cucumbers, all drizzled with tangy balsamic vinaigrette. Whether you're looking for a light and satisfying meal or a nutritious side dish, this salad is sure to hit the spot.", "https://prm392.blob.core.windows.net/prm392/GrilledChickenSalad.jpg", true, null, 11.99, "Grilled Chicken Salad", null, "Grilled chicken breast, mixed greens, cherry tomatoes, cucumbers, balsamic vinaigrette" },
                    { new Guid("2819c023-927e-4546-a961-2c400ed4dd75"), "A refreshing cola drink with a hint of vanilla and caramel flavors.", new Guid("82de5b3d-ca35-420d-8e98-cc432b510201"), "The Classic Coke is a timeless favorite, featuring a blend of carbonated water, sugar, caffeine, and natural flavors. It offers a crisp and refreshing taste with a hint of vanilla and caramel notes, making it a perfect companion to any meal or snack. Whether you're enjoying a burger, pizza, or dessert, this iconic cola drink is sure to quench your thirst and satisfy your cravings.", "https://prm392.blob.core.windows.net/prm392/ClassicCoke.jpg", true, null, 2.4900000000000002, "Classic Coke", null, "Carbonated water, sugar, caffeine, natural flavors" },
                    { new Guid("3a1d5bae-ceda-48c0-af14-738874c3dfec"), "Crispy, spicy chicken breast with creamy mayo, pickles, and lettuce on a soft brioche bun.", new Guid("5a2834d9-2630-4d1f-8126-daa29b800e78"), "For those who love a kick of heat, the Spicy Chicken Burger delivers! A succulent chicken breast is marinated in a fiery blend of spices, coated in crispy breadcrumbs, and fried to golden perfection. Paired with creamy mayonnaise, crunchy pickles, and fresh lettuce, all inside a soft, buttery brioche bun. This burger combines a spicy crunch with the cool creaminess of the mayo, making each bite satisfying and full of flavor.", "https://prm392.blob.core.windows.net/prm392/SpicyChickenBurger.jpg", true, null, 9.4900000000000002, "Spicy Chicken Burger", null, "Lettuce, pickles, spicy mayonnaise, chicken" },
                    { new Guid("3e54a838-c934-46d9-952a-2a9be637ebcc"), "A classic pizza with tomato sauce, mozzarella cheese, and spicy pepperoni slices.", new Guid("2d85ef10-9237-46e8-8131-955eb56c27f0"), "The Pepperoni Pizza is a crowd-pleaser, featuring a generous layer of tangy tomato sauce, gooey mozzarella cheese, and zesty pepperoni slices. Each bite offers a perfect balance of flavors and textures, with the spicy pepperoni adding a kick of heat to the savory cheese and sauce. Whether you're hosting a party, enjoying a movie night, or simply craving a slice of comfort food, this pizza is sure to hit the spot.", "https://prm392.blob.core.windows.net/prm392/PepperoniPizza.jpg", true, null, 12.99, "Pepperoni Pizza", null, "Tomato sauce, mozzarella cheese, pepperoni slices" },
                    { new Guid("589fd634-9c23-4a17-8c6c-da5aa0caa12b"), "A classic Italian dessert made with layers of coffee-soaked ladyfingers and mascarpone cream.", new Guid("804563c3-05f3-4997-98fd-b23e4a310fb6"), "The Tiramisu is a beloved Italian dessert that combines the rich flavors of coffee, cocoa, and mascarpone cheese in a luscious and creamy treat. This dessert features layers of coffee-soaked ladyfingers, creamy mascarpone cheese, and a dusting of cocoa powder, creating a perfect balance of flavors and textures. Whether you're a fan of coffee-infused desserts or simply enjoy a taste of Italy, this Tiramisu is sure to transport you to a cozy cafe in Rome.", "https://prm392.blob.core.windows.net/prm392/Tiramisu.jpg", true, null, 7.9900000000000002, "Tiramisu", null, "Ladyfingers, coffee, mascarpone cheese, cocoa powder" },
                    { new Guid("609aa6e2-eedc-46c9-9ebe-45a4b23d7dc6"), "Crispy fried chicken tenders with your choice of BBQ, buffalo, or honey mustard sauce.", new Guid("beffabc8-6f9f-4d08-b69a-8cb5226e8486"), "The Crispy Chicken Tenders are a delicious and satisfying meal that offers a perfect balance of crispy coating and tender chicken meat. These tenders are fried to golden perfection and served with your choice of BBQ, buffalo, or honey mustard sauce, adding a burst of flavor and heat to each bite. Whether you're looking for a quick and tasty meal or a shareable appetizer, these tenders are sure to hit the spot.", "https://prm392.blob.core.windows.net/prm392/CrispyChickenTender.jpg", true, null, 10.99, "Crispy Chicken Tenders", null, "Chicken tenders, flour, salt, pepper, sauce of choice" },
                    { new Guid("83c88bee-7638-4499-9a9c-49701b7db3e9"), " A juicy beef patty with fresh lettuce, tomatoes, onions, and cheddar cheese, served on a sesame seed bun.", new Guid("5a2834d9-2630-4d1f-8126-daa29b800e78"), "The Classic Beef Burger is a timeless favorite, featuring a perfectly seasoned, 100% beef patty grilled to perfection. Topped with crisp lettuce, ripe tomatoes, tangy pickles, and a slice of melted cheddar cheese, this burger is nestled between a toasted sesame seed bun. Each bite offers a mouthwatering combination of fresh, savory, and slightly tangy flavors, perfect for burger enthusiasts.", "https://prm392.blob.core.windows.net/prm392/ClassicBeefBurger.jpg", true, null, 8.9900000000000002, "Classic Beef Burger", null, "Beef, tomato, lettuce, mayonnaise, tomato sauce" },
                    { new Guid("8abdff8c-6924-44e7-b9f6-4b79c0aa2dff"), "Crispy fried chicken wings with your choice of BBQ, buffalo, or honey mustard sauce.", new Guid("beffabc8-6f9f-4d08-b69a-8cb5226e8486"), "The Crispy Chicken Wings are a crowd-pleasing appetizer that offers a perfect balance of crispy skin and tender meat. These wings are fried to golden perfection and tossed in your choice of BBQ, buffalo, or honey mustard sauce, adding a burst of flavor and heat to each bite. Whether you're hosting a party, watching the game, or simply craving a savory snack, these wings are sure to hit the spot.", "https://prm392.blob.core.windows.net/prm392/CrispyChickenWing.jpg", true, null, 9.9900000000000002, "Crispy Chicken Wings", null, "Chicken wings, flour, salt, pepper, sauce of choice" },
                    { new Guid("8b4970ae-2a0a-4235-9406-9490d75039ae"), "A tropical pizza with tomato sauce, mozzarella cheese, ham, and pineapple chunks.", new Guid("2d85ef10-9237-46e8-8131-955eb56c27f0"), "The Hawaiian Pizza is a tropical delight, featuring a sweet and savory combination of ingredients. It starts with a tangy tomato sauce and a layer of gooey mozzarella cheese, topped with smoky ham slices and juicy pineapple chunks. Each bite offers a burst of flavors, from the salty ham to the sweet pineapple, creating a unique and satisfying taste experience. Whether you're a fan of exotic toppings or simply enjoy a taste of the tropics, this pizza is sure to transport you to a sunny paradise.", "https://prm392.blob.core.windows.net/prm392/HawaiianPizza.jpg", true, null, 13.99, "Hawaiian Pizza", null, "Tomato sauce, mozzarella cheese, ham, pineapple chunks" },
                    { new Guid("c6fd73b6-c00c-40fa-bb90-aca455c989e6"), "A rich and fudgy chocolate brownie topped with a scoop of vanilla ice cream.", new Guid("804563c3-05f3-4997-98fd-b23e4a310fb6"), "The Chocolate Brownie is a decadent dessert that combines the rich, fudgy texture of a brownie with the creamy sweetness of vanilla ice cream. Each bite offers a perfect balance of flavors and textures, with the warm, gooey brownie complemented by the cold, smooth ice cream. Whether you're a chocolate lover, a dessert enthusiast, or simply looking for a sweet treat to end your meal, this dessert is sure to satisfy your cravings.", "https://prm392.blob.core.windows.net/prm392/ChocolateBrownie.jpg", true, null, 5.9900000000000002, "Chocolate Brownie", null, "Chocolate, flour, sugar, eggs, vanilla ice cream" },
                    { new Guid("cc5ec930-95df-4fa6-b038-e5b361945b02"), "A plant-based patty with avocado, vegan cheese, and fresh greens on a multigrain bun.", new Guid("5a2834d9-2630-4d1f-8126-daa29b800e78"), "A fresh and nutritious choice, the Vegan Avocado Burger features a flavorful plant-based patty made from lentils, mushrooms, and chickpeas. It's topped with creamy avocado slices, vegan cheddar cheese, mixed greens, and a hint of garlic aioli. All these ingredients are packed inside a wholesome multigrain bun, offering a satisfying and guilt-free experience without sacrificing taste. This burger is ideal for vegans and health-conscious customers alike.", "https://prm392.blob.core.windows.net/prm392/VeganAvocadoBurger.jpg", true, null, 12.99, "Vegan Avocado Burger", null, "Avocado, vegan cheese, mixed greens, multigrain bun" },
                    { new Guid("ff91e16b-f2d5-4223-9b5f-d2e0c012544a"), "A creamy and tangy cheesecake with a graham cracker crust and a drizzle of raspberry sauce.", new Guid("804563c3-05f3-4997-98fd-b23e4a310fb6"), "The New York Cheesecake is a classic dessert that never goes out of style. It features a rich and creamy cheesecake filling on a buttery graham cracker crust, topped with a sweet and tangy raspberry sauce. Each bite offers a perfect balance of flavors and textures, with the smooth, velvety cheesecake complemented by the crunchy crust and fruity sauce. Whether you're a fan of traditional recipes or simply appreciate a good slice of cheesecake, this dessert is sure to delight your taste buds.", "https://prm392.blob.core.windows.net/prm392/NewYorkCheeseCake.jpg", true, null, 6.9900000000000002, "New York Cheesecake", null, "Cream cheese, graham crackers, sugar, eggs, raspberry sauce" }
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
                name: "IX_CartItems_CartID",
                table: "CartItems",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductID",
                table: "CartItems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserID",
                table: "Carts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_UserID",
                table: "ChatMessages",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserID",
                table: "Notifications",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartID",
                table: "Orders",
                column: "CartID",
                unique: true,
                filter: "[CartID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StoreLocationID",
                table: "Orders",
                column: "StoreLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderID",
                table: "Payments",
                column: "OrderID",
                unique: true,
                filter: "[OrderID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderID",
                table: "Products",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoreID",
                table: "Products",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_StoreLocations_StoreID",
                table: "StoreLocations",
                column: "StoreID");
        }

        /// <inheritdoc />
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
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "StoreLocations");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
