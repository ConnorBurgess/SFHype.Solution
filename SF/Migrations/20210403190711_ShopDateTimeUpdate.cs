using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SFHype.Migrations
{
    public partial class ShopDateTimeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DayChange",
                table: "Shops",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: -2,
                column: "Originated",
                value: new DateTime(2021, 4, 3, 12, 7, 11, 450, DateTimeKind.Local).AddTicks(3208));

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: -1,
                column: "Originated",
                value: new DateTime(2021, 4, 3, 12, 7, 11, 450, DateTimeKind.Local).AddTicks(5341));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayChange",
                table: "Shops");

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: -2,
                column: "Originated",
                value: new DateTime(2021, 4, 3, 10, 29, 33, 141, DateTimeKind.Local).AddTicks(5459));

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: -1,
                column: "Originated",
                value: new DateTime(2021, 4, 3, 10, 29, 33, 141, DateTimeKind.Local).AddTicks(7362));
        }
    }
}
