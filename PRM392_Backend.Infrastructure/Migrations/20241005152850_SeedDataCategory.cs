using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PRM392_Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CategoryName", "IsActive" },
                values: new object[,]
                {
                    { new Guid("2d85ef10-9237-46e8-8131-955eb56c27f0"), "Pizzas", true },
                    { new Guid("5a2834d9-2630-4d1f-8126-daa29b800e78"), "Burgers", true },
                    { new Guid("804563c3-05f3-4997-98fd-b23e4a310fb6"), "Desserts", true },
                    { new Guid("82de5b3d-ca35-420d-8e98-cc432b510201"), "Drinks", true },
                    { new Guid("beffabc8-6f9f-4d08-b69a-8cb5226e8486"), "Chickens", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("2d85ef10-9237-46e8-8131-955eb56c27f0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("5a2834d9-2630-4d1f-8126-daa29b800e78"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("804563c3-05f3-4997-98fd-b23e4a310fb6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("82de5b3d-ca35-420d-8e98-cc432b510201"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("beffabc8-6f9f-4d08-b69a-8cb5226e8486"));
        }
    }
}
