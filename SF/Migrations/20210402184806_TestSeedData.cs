using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SFHype.Migrations
{
    public partial class TestSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShopID",
                table: "Shops",
                newName: "ShopId");

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopId", "Describe", "Hype", "Name", "Originated" },
                values: new object[] { -2, "A cool shop.", 0, "SF Shop 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopId", "Describe", "Hype", "Name", "Originated" },
                values: new object[] { -1, "Another cool shop.", 0, "SF Shop 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: -1);

            migrationBuilder.RenameColumn(
                name: "ShopId",
                table: "Shops",
                newName: "ShopID");
        }
    }
}
