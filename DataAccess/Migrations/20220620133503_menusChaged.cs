using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class menusChaged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Sweets_SweetId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "SweeId",
                table: "Menus");

            migrationBuilder.AlterColumn<int>(
                name: "SweetId",
                table: "Menus",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Sweets_SweetId",
                table: "Menus",
                column: "SweetId",
                principalTable: "Sweets",
                principalColumn: "SweetId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Sweets_SweetId",
                table: "Menus");

            migrationBuilder.AlterColumn<int>(
                name: "SweetId",
                table: "Menus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SweeId",
                table: "Menus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Sweets_SweetId",
                table: "Menus",
                column: "SweetId",
                principalTable: "Sweets",
                principalColumn: "SweetId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
