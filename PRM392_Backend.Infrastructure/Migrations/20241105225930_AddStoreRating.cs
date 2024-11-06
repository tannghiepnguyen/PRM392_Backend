using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRM392_Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStoreRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Stores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("036975aa-0bae-455a-a559-d0c914a43b27"),
                column: "Rating",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("0edc6c88-6d86-42e7-9e1c-ff5821f8e366"),
                column: "Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("275dd30a-7b06-465a-9731-e0b75f2b4441"),
                column: "Rating",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("4fbb2d9c-9eb2-4098-aed3-bbb7303e58c5"),
                column: "Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("6d0ab2e1-5b77-4d9a-b678-63f1a52cf274"),
                column: "Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("6d2f69e3-678b-4937-bd1d-06e9b37056e0"),
                column: "Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("ad94e519-8ee5-442e-b013-df96cb74594b"),
                column: "Rating",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("b1658d47-bc38-4690-9035-85c2e2d85d7c"),
                column: "Rating",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("b7b2e729-13b0-44cf-b4f9-616bffebda5d"),
                column: "Rating",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("c3e07e4f-118e-43c5-9a3e-66057c5bc038"),
                column: "Rating",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("d13d2d4a-639d-4f28-a073-d3eaf8c2a3f6"),
                column: "Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("deb70b97-b1fc-48f6-860c-fe9c15bcc4c7"),
                column: "Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("df8b5e1a-c3b3-47e0-b59f-7c559b3bde59"),
                column: "Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("ec2d6842-2177-4852-8f3e-52d99ed8a1b5"),
                column: "Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: new Guid("fd9dbb8e-6f91-45c9-bb9e-517bd4d129ab"),
                column: "Rating",
                value: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Stores");
        }
    }
}
