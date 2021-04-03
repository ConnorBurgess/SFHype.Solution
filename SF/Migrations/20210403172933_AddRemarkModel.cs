using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SFHype.Migrations
{
    public partial class AddRemarkModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Remark",
                columns: table => new
                {
                    RemarkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Originated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remark", x => x.RemarkId);
                    table.ForeignKey(
                        name: "FK_Remark_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "ShopId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Remark_ShopId",
                table: "Remark",
                column: "ShopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Remark");

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: -2,
                column: "Originated",
                value: new DateTime(2021, 4, 2, 14, 37, 5, 808, DateTimeKind.Local).AddTicks(1579));

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: -1,
                column: "Originated",
                value: new DateTime(2021, 4, 2, 14, 37, 5, 808, DateTimeKind.Local).AddTicks(2772));
        }
    }
}
