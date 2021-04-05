using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SFHype.Migrations
{
    public partial class ShopPropRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HypeRatio",
                table: "Shops",
                newName: "Scale");

            migrationBuilder.AddColumn<float>(
                name: "DecrementScale",
                table: "Shops",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: -2,
                columns: new[] { "DecrementScale", "Originated", "Scale" },
                values: new object[] { 1E-06f, new DateTime(2021, 4, 5, 0, 25, 45, 458, DateTimeKind.Local).AddTicks(2458), 0.001f });

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: -1,
                columns: new[] { "DecrementScale", "Originated", "Scale" },
                values: new object[] { 1E-06f, new DateTime(2021, 4, 5, 0, 25, 45, 458, DateTimeKind.Local).AddTicks(3760), 0.001f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DecrementScale",
                table: "Shops");

            migrationBuilder.RenameColumn(
                name: "Scale",
                table: "Shops",
                newName: "HypeRatio");

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: -2,
                columns: new[] { "HypeRatio", "Originated" },
                values: new object[] { 1f, new DateTime(2021, 4, 3, 12, 35, 40, 536, DateTimeKind.Local).AddTicks(5867) });

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: -1,
                columns: new[] { "HypeRatio", "Originated" },
                values: new object[] { 1f, new DateTime(2021, 4, 3, 12, 35, 40, 536, DateTimeKind.Local).AddTicks(7502) });
        }
    }
}
