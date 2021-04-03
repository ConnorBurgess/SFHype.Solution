using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SFHype.Migrations
{
    public partial class ShopRemarkAddIp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IpLog",
                table: "Shops",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ip",
                table: "Remark",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: -2,
                column: "Originated",
                value: new DateTime(2021, 4, 3, 12, 35, 40, 536, DateTimeKind.Local).AddTicks(5867));

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: -1,
                column: "Originated",
                value: new DateTime(2021, 4, 3, 12, 35, 40, 536, DateTimeKind.Local).AddTicks(7502));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IpLog",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "Ip",
                table: "Remark");

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
    }
}
