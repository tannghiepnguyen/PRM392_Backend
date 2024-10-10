using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PRM392_Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "BriefDescription", "CategoryId", "FullDescription", "ImageURL", "IsActive", "Price", "ProductName", "TechnicalSpecification" },
                values: new object[,]
                {
                    { new Guid("067e22e7-1d7d-43e9-927e-63aad59be917"), "A refreshing blend of ripe mango, coconut milk, and pineapple for a tropical escape in a glass.", new Guid("82de5b3d-ca35-420d-8e98-cc432b510201"), "The Tropical Mango Smoothie is a vibrant and refreshing drink that brings the taste of the tropics to your table. This smoothie is made with ripe mangoes, sweet pineapple chunks, and creamy coconut milk, blended to a silky smooth consistency. It’s naturally sweet and packed with vitamins, offering a deliciously healthy way to cool down on a warm day. The hint of lime juice adds a refreshing citrus kick, making this smoothie both energizing and satisfying.", "https://prm392.blob.core.windows.net/prm392/TropicalMangoSmoothie.jpg", true, 2.9900000000000002, "Tropical Mango Smoothie", "Fresh mango, pineapple, coconut milk, lime juice, ice" },
                    { new Guid("08a7cf22-90a7-4823-9fe6-4264d3ee0a87"), "A classic pizza with tomato sauce, mozzarella cheese, and fresh basil leaves.", new Guid("2d85ef10-9237-46e8-8131-955eb56c27f0"), "The Margherita Pizza is a timeless classic that never goes out of style. It features a thin, crispy crust topped with tangy tomato sauce, creamy mozzarella cheese, and fragrant basil leaves. Each bite offers a burst of fresh flavors and a perfect balance of textures, making it a favorite among pizza lovers. Whether you're a fan of traditional recipes or simply appreciate the simplicity of good ingredients, this pizza is sure to satisfy your cravings.", "https://prm392.blob.core.windows.net/prm392/MargheritaPizza.jpg", true, 10.99, "Margherita Pizza", "Tomato sauce, mozzarella cheese, basil leaves" },
                    { new Guid("09fdd4f0-74d9-498b-9026-56237a7573f3"), "A refreshing tea drink with a hint of lemon and sweetened with sugar.", new Guid("82de5b3d-ca35-420d-8e98-cc432b510201"), "The Iced Tea is a classic beverage that offers a cool and refreshing taste, perfect for hot summer days or as a thirst-quenching treat. Made from brewed tea leaves, sweetened with sugar, and flavored with a hint of lemon, this drink is both invigorating and satisfying. Whether you're looking for a caffeine-free alternative to soda or simply enjoy the taste of tea, this iced tea is sure to hit the spot.", "https://prm392.blob.core.windows.net/prm392/IcedTea.jpg", true, 2.9900000000000002, "Iced Tea", "Brewed tea leaves, sugar, lemon flavor" },
                    { new Guid("13298515-27ac-4116-8394-81f6deaa4585"), "Grilled chicken breast on a bed of mixed greens, cherry tomatoes, cucumbers, and balsamic vinaigrette.", new Guid("beffabc8-6f9f-4d08-b69a-8cb5226e8486"), "The Grilled Chicken Salad is a fresh and healthy option that offers a perfect balance of flavors and textures. It features a juicy grilled chicken breast on a bed of crisp mixed greens, cherry tomatoes, and cucumbers, all drizzled with tangy balsamic vinaigrette. Whether you're looking for a light and satisfying meal or a nutritious side dish, this salad is sure to hit the spot.", "https://prm392.blob.core.windows.net/prm392/GrilledChickenSalad.jpg", true, 11.99, "Grilled Chicken Salad", "Grilled chicken breast, mixed greens, cherry tomatoes, cucumbers, balsamic vinaigrette" },
                    { new Guid("2819c023-927e-4546-a961-2c400ed4dd75"), "A refreshing cola drink with a hint of vanilla and caramel flavors.", new Guid("82de5b3d-ca35-420d-8e98-cc432b510201"), "The Classic Coke is a timeless favorite, featuring a blend of carbonated water, sugar, caffeine, and natural flavors. It offers a crisp and refreshing taste with a hint of vanilla and caramel notes, making it a perfect companion to any meal or snack. Whether you're enjoying a burger, pizza, or dessert, this iconic cola drink is sure to quench your thirst and satisfy your cravings.", "https://prm392.blob.core.windows.net/prm392/ClassicCoke.jpg", true, 2.4900000000000002, "Classic Coke", "Carbonated water, sugar, caffeine, natural flavors" },
                    { new Guid("3a1d5bae-ceda-48c0-af14-738874c3dfec"), "Crispy, spicy chicken breast with creamy mayo, pickles, and lettuce on a soft brioche bun.", new Guid("5a2834d9-2630-4d1f-8126-daa29b800e78"), "For those who love a kick of heat, the Spicy Chicken Burger delivers! A succulent chicken breast is marinated in a fiery blend of spices, coated in crispy breadcrumbs, and fried to golden perfection. Paired with creamy mayonnaise, crunchy pickles, and fresh lettuce, all inside a soft, buttery brioche bun. This burger combines a spicy crunch with the cool creaminess of the mayo, making each bite satisfying and full of flavor.", "https://prm392.blob.core.windows.net/prm392/SpicyChickenBurger.jpg", true, 9.4900000000000002, "Spicy Chicken Burger", "Lettuce, pickles, spicy mayonnaise, chicken" },
                    { new Guid("3e54a838-c934-46d9-952a-2a9be637ebcc"), "A classic pizza with tomato sauce, mozzarella cheese, and spicy pepperoni slices.", new Guid("2d85ef10-9237-46e8-8131-955eb56c27f0"), "The Pepperoni Pizza is a crowd-pleaser, featuring a generous layer of tangy tomato sauce, gooey mozzarella cheese, and zesty pepperoni slices. Each bite offers a perfect balance of flavors and textures, with the spicy pepperoni adding a kick of heat to the savory cheese and sauce. Whether you're hosting a party, enjoying a movie night, or simply craving a slice of comfort food, this pizza is sure to hit the spot.", "https://prm392.blob.core.windows.net/prm392/PepperoniPizza.jpg", true, 12.99, "Pepperoni Pizza", "Tomato sauce, mozzarella cheese, pepperoni slices" },
                    { new Guid("589fd634-9c23-4a17-8c6c-da5aa0caa12b"), "A classic Italian dessert made with layers of coffee-soaked ladyfingers and mascarpone cream.", new Guid("804563c3-05f3-4997-98fd-b23e4a310fb6"), "The Tiramisu is a beloved Italian dessert that combines the rich flavors of coffee, cocoa, and mascarpone cheese in a luscious and creamy treat. This dessert features layers of coffee-soaked ladyfingers, creamy mascarpone cheese, and a dusting of cocoa powder, creating a perfect balance of flavors and textures. Whether you're a fan of coffee-infused desserts or simply enjoy a taste of Italy, this Tiramisu is sure to transport you to a cozy cafe in Rome.", "https://prm392.blob.core.windows.net/prm392/Tiramisu.jpg", true, 7.9900000000000002, "Tiramisu", "Ladyfingers, coffee, mascarpone cheese, cocoa powder" },
                    { new Guid("609aa6e2-eedc-46c9-9ebe-45a4b23d7dc6"), "Crispy fried chicken tenders with your choice of BBQ, buffalo, or honey mustard sauce.", new Guid("beffabc8-6f9f-4d08-b69a-8cb5226e8486"), "The Crispy Chicken Tenders are a delicious and satisfying meal that offers a perfect balance of crispy coating and tender chicken meat. These tenders are fried to golden perfection and served with your choice of BBQ, buffalo, or honey mustard sauce, adding a burst of flavor and heat to each bite. Whether you're looking for a quick and tasty meal or a shareable appetizer, these tenders are sure to hit the spot.", "https://prm392.blob.core.windows.net/prm392/CrispyChickenTender.jpg", true, 10.99, "Crispy Chicken Tenders", "Chicken tenders, flour, salt, pepper, sauce of choice" },
                    { new Guid("83c88bee-7638-4499-9a9c-49701b7db3e9"), " A juicy beef patty with fresh lettuce, tomatoes, onions, and cheddar cheese, served on a sesame seed bun.", new Guid("5a2834d9-2630-4d1f-8126-daa29b800e78"), "The Classic Beef Burger is a timeless favorite, featuring a perfectly seasoned, 100% beef patty grilled to perfection. Topped with crisp lettuce, ripe tomatoes, tangy pickles, and a slice of melted cheddar cheese, this burger is nestled between a toasted sesame seed bun. Each bite offers a mouthwatering combination of fresh, savory, and slightly tangy flavors, perfect for burger enthusiasts.", "https://prm392.blob.core.windows.net/prm392/ClassicBeefBurger.jpg", true, 8.9900000000000002, "Classic Beef Burger", "Beef, tomato, lettuce, mayonnaise, tomato sauce" },
                    { new Guid("8abdff8c-6924-44e7-b9f6-4b79c0aa2dff"), "Crispy fried chicken wings with your choice of BBQ, buffalo, or honey mustard sauce.", new Guid("beffabc8-6f9f-4d08-b69a-8cb5226e8486"), "The Crispy Chicken Wings are a crowd-pleasing appetizer that offers a perfect balance of crispy skin and tender meat. These wings are fried to golden perfection and tossed in your choice of BBQ, buffalo, or honey mustard sauce, adding a burst of flavor and heat to each bite. Whether you're hosting a party, watching the game, or simply craving a savory snack, these wings are sure to hit the spot.", "https://prm392.blob.core.windows.net/prm392/CrispyChickenWing.jpg", true, 9.9900000000000002, "Crispy Chicken Wings", "Chicken wings, flour, salt, pepper, sauce of choice" },
                    { new Guid("8b4970ae-2a0a-4235-9406-9490d75039ae"), "A tropical pizza with tomato sauce, mozzarella cheese, ham, and pineapple chunks.", new Guid("2d85ef10-9237-46e8-8131-955eb56c27f0"), "The Hawaiian Pizza is a tropical delight, featuring a sweet and savory combination of ingredients. It starts with a tangy tomato sauce and a layer of gooey mozzarella cheese, topped with smoky ham slices and juicy pineapple chunks. Each bite offers a burst of flavors, from the salty ham to the sweet pineapple, creating a unique and satisfying taste experience. Whether you're a fan of exotic toppings or simply enjoy a taste of the tropics, this pizza is sure to transport you to a sunny paradise.", "https://prm392.blob.core.windows.net/prm392/HawaiianPizza.jpg", true, 13.99, "Hawaiian Pizza", "Tomato sauce, mozzarella cheese, ham, pineapple chunks" },
                    { new Guid("c6fd73b6-c00c-40fa-bb90-aca455c989e6"), "A rich and fudgy chocolate brownie topped with a scoop of vanilla ice cream.", new Guid("804563c3-05f3-4997-98fd-b23e4a310fb6"), "The Chocolate Brownie is a decadent dessert that combines the rich, fudgy texture of a brownie with the creamy sweetness of vanilla ice cream. Each bite offers a perfect balance of flavors and textures, with the warm, gooey brownie complemented by the cold, smooth ice cream. Whether you're a chocolate lover, a dessert enthusiast, or simply looking for a sweet treat to end your meal, this dessert is sure to satisfy your cravings.", "https://prm392.blob.core.windows.net/prm392/ChocolateBrownie.jpg", true, 5.9900000000000002, "Chocolate Brownie", "Chocolate, flour, sugar, eggs, vanilla ice cream" },
                    { new Guid("cc5ec930-95df-4fa6-b038-e5b361945b02"), "A plant-based patty with avocado, vegan cheese, and fresh greens on a multigrain bun.", new Guid("5a2834d9-2630-4d1f-8126-daa29b800e78"), "A fresh and nutritious choice, the Vegan Avocado Burger features a flavorful plant-based patty made from lentils, mushrooms, and chickpeas. It's topped with creamy avocado slices, vegan cheddar cheese, mixed greens, and a hint of garlic aioli. All these ingredients are packed inside a wholesome multigrain bun, offering a satisfying and guilt-free experience without sacrificing taste. This burger is ideal for vegans and health-conscious customers alike.", "https://prm392.blob.core.windows.net/prm392/VeganAvocadoBurger.jpg", true, 12.99, "Vegan Avocado Burger", "Avocado, vegan cheese, mixed greens, multigrain bun" },
                    { new Guid("ff91e16b-f2d5-4223-9b5f-d2e0c012544a"), "A creamy and tangy cheesecake with a graham cracker crust and a drizzle of raspberry sauce.", new Guid("804563c3-05f3-4997-98fd-b23e4a310fb6"), "The New York Cheesecake is a classic dessert that never goes out of style. It features a rich and creamy cheesecake filling on a buttery graham cracker crust, topped with a sweet and tangy raspberry sauce. Each bite offers a perfect balance of flavors and textures, with the smooth, velvety cheesecake complemented by the crunchy crust and fruity sauce. Whether you're a fan of traditional recipes or simply appreciate a good slice of cheesecake, this dessert is sure to delight your taste buds.", "https://prm392.blob.core.windows.net/prm392/NewYorkCheeseCake.jpg", true, 6.9900000000000002, "New York Cheesecake", "Cream cheese, graham crackers, sugar, eggs, raspberry sauce" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("067e22e7-1d7d-43e9-927e-63aad59be917"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("08a7cf22-90a7-4823-9fe6-4264d3ee0a87"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("09fdd4f0-74d9-498b-9026-56237a7573f3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("13298515-27ac-4116-8394-81f6deaa4585"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("2819c023-927e-4546-a961-2c400ed4dd75"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("3a1d5bae-ceda-48c0-af14-738874c3dfec"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("3e54a838-c934-46d9-952a-2a9be637ebcc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("589fd634-9c23-4a17-8c6c-da5aa0caa12b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("609aa6e2-eedc-46c9-9ebe-45a4b23d7dc6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("83c88bee-7638-4499-9a9c-49701b7db3e9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("8abdff8c-6924-44e7-b9f6-4b79c0aa2dff"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("8b4970ae-2a0a-4235-9406-9490d75039ae"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("c6fd73b6-c00c-40fa-bb90-aca455c989e6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("cc5ec930-95df-4fa6-b038-e5b361945b02"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("ff91e16b-f2d5-4223-9b5f-d2e0c012544a"));
        }
    }
}
