using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SFHype.Migrations
{
    public partial class ShopSetIdProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: -1);

            migrationBuilder.AddColumn<float>(
                name: "HypeRatio",
                table: "Shops",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HypeRatio",
                table: "Shops");

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopId", "Describe", "Dislikes", "Hype", "Likes", "Name", "Originated", "Remark", "Type" },
                values: new object[] { -2, "A cool shop.", 0, 0f, 0, "SF Shop 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Restaurant" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopId", "Describe", "Dislikes", "Hype", "Likes", "Name", "Originated", "Remark", "Type" },
                values: new object[] { -1, "Another cool shop.", 0, 0f, 0, "SF Shop 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });
        }
    }
}
