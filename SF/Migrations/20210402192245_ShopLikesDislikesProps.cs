using Microsoft.EntityFrameworkCore.Migrations;

namespace SFHype.Migrations
{
    public partial class ShopLikesDislikesProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Hype",
                table: "Shops",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Dislikes",
                table: "Shops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Shops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: -2,
                column: "Hype",
                value: 0f);

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: -1,
                column: "Hype",
                value: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dislikes",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Shops");

            migrationBuilder.AlterColumn<int>(
                name: "Hype",
                table: "Shops",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: -2,
                column: "Hype",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "ShopId",
                keyValue: -1,
                column: "Hype",
                value: 0);
        }
    }
}
