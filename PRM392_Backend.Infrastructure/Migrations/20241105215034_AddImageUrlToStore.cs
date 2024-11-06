using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PRM392_Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlToStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "ID", "Address", "ImageUrl", "IsActive", "StoreName" },
                values: new object[,]
                {
                    { new Guid("4fbb2d9c-9eb2-4098-aed3-bbb7303e58c5"), "22 Nguyen Thi Minh Khai St, District 1, Ho Chi Minh City", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS6YlQuV6RqkMK4oQPLkZGwf50JO-0owQaQKg&s", true, "Alfredo's Pizzeria" },
                    { new Guid("6d0ab2e1-5b77-4d9a-b678-63f1a52cf274"), "34 Le Lai St, District 1, Ho Chi Minh City", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSJeYIrTFi95VInO-ft4pLYqMUSvzE_iWcu9A&s", true, "Shogun Burger" },
                    { new Guid("6d2f69e3-678b-4937-bd1d-06e9b37056e0"), "18 Nguyen Thi Minh Khai St, District 1, Ho Chi Minh City", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ-4e_x-a_vkQT8gM247nyzTaksk99MInwAXA&s", true, "Ming's Chinese Restaurant" },
                    { new Guid("ad94e519-8ee5-442e-b013-df96cb74594b"), "27 Ton Duc Thang St, District 1, Ho Chi Minh City", "https://www.sushiteivietnam.com/wp-content/uploads/2024/08/logo-scaled.webp", true, "Sushi Tei" },
                    { new Guid("b7b2e729-13b0-44cf-b4f9-616bffebda5d"), "456 Pham Ngoc Thach St, District 3, Ho Chi Minh City", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQQigCssnKf-N2zAzzOsWJtl6_A_J1t1oPjig&s", true, "The Burger Joint" },
                    { new Guid("c3e07e4f-118e-43c5-9a3e-66057c5bc038"), "100 Nguyen Thi Minh Khai, District 1, Ho Chi Minh City", "https://play-lh.googleusercontent.com/vDn0tgGBTcZ_Q8QhSdjuhvMNA4GUJK8VS_pZ0Fy-miUMDodMNeUbDfjMGEwFB1vERPQ", true, "The Pizza Company" },
                    { new Guid("d13d2d4a-639d-4f28-a073-d3eaf8c2a3f6"), "5 Le Duan St, District 1, Ho Chi Minh City", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSR11F0IgZlK1JbWkggHGMf2GxTr64MAt3HfQ&s", true, "Kong's Asian Cuisine Restaurant" },
                    { new Guid("df8b5e1a-c3b3-47e0-b59f-7c559b3bde59"), "58 Le Loi St, District 1, Ho Chi Minh City", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTWJbbHgN1qGYIeMiAqYxFiavSbahUYHE0e2g&s", true, "Trattoria Antonio" },
                    { new Guid("ec2d6842-2177-4852-8f3e-52d99ed8a1b5"), "17A Hai Ba Trung St, District 1, Ho Chi Minh City", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRhoacfNPgi_5pAVK08-wLGYwLfaE3FsqNA1w&s", true, "Cucina Italian Restaurant" },
                    { new Guid("fd9dbb8e-6f91-45c9-bb9e-517bd4d129ab"), "25 Le Thanh Ton St, District 1, Ho Chi Minh City", "https://sushiworld.com.vn/wp-content/uploads/2020/10/logo-sushi-world.png", true, "Sushi World" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("4fbb2d9c-9eb2-4098-aed3-bbb7303e58c5"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("6d0ab2e1-5b77-4d9a-b678-63f1a52cf274"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("6d2f69e3-678b-4937-bd1d-06e9b37056e0"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("ad94e519-8ee5-442e-b013-df96cb74594b"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("b7b2e729-13b0-44cf-b4f9-616bffebda5d"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("c3e07e4f-118e-43c5-9a3e-66057c5bc038"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("d13d2d4a-639d-4f28-a073-d3eaf8c2a3f6"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("df8b5e1a-c3b3-47e0-b59f-7c559b3bde59"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("ec2d6842-2177-4852-8f3e-52d99ed8a1b5"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("fd9dbb8e-6f91-45c9-bb9e-517bd4d129ab"));
        }
    }
}
