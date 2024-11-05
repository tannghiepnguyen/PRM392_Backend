using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRM392_Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlToStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("036975aa-0bae-455a-a559-d0c914a43b27"),
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSDStT3T--pHLciOb93FLN1Nlmvp8Bzqg3wPw&s");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("0edc6c88-6d86-42e7-9e1c-ff5821f8e366"),
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcROBn_ESD2kvsswrE6qRJOM1IPhS8JtBE4ddQ&s");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("275dd30a-7b06-465a-9731-e0b75f2b4441"),
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS1_Yesq9xjLKw2mvgZNgk0BcjtZ8_9rzg8jg&s");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("b1658d47-bc38-4690-9035-85c2e2d85d7c"),
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRSwI0EgrEZKcx6VRufT4vhMgjDQL35kdv8GA&s");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("deb70b97-b1fc-48f6-860c-fe9c15bcc4c7"),
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQRRL5AQ1LfPEz2Lvc0fjQhFYCmQ09vVmpzpA&s");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Stores");
        }
    }
}
