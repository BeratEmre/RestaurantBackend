using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class IdBecomeGenericAllProjectUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SweetId",
                table: "Sweets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OrderDetailId",
                table: "OrderDetails",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Menus",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FoodId",
                table: "Foods",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DrinkId",
                table: "Drinks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sweets",
                newName: "SweetId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OrderDetails",
                newName: "OrderDetailId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Menus",
                newName: "MenuId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Foods",
                newName: "FoodId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Drinks",
                newName: "DrinkId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "CategoryId");
        }
    }
}
