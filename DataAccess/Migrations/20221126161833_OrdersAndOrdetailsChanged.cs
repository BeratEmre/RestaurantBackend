using System;
using System.Data;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.VisualBasic;

namespace DataAccess.Migrations
{
    public partial class OrdersAndOrdetailsChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_OrderDetails_Orders_OrderId",
            //    table: "OrderDetails");

            //migrationBuilder.DropForeignKey(
            //    table: "Orders",
            //    name: "FK_Orders_Drinks_DrinkId"
            //    );

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Orders_Foods_FoodId",
            //    table: "Orders");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Orders_Menus_MenuId",
            //    table: "Orders");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Orders_Sweets_SweetId",
            //    table: "Orders");

            //migrationBuilder.DropIndex(
            //    name: "IX_Orders_DrinkId",
            //    table: "Orders");

            //migrationBuilder.DropIndex(
            //    name: "IX_Orders_FoodId",
            //    table: "Orders");

            //migrationBuilder.DropIndex(
            //    name: "IX_Orders_MenuId",
            //    table: "Orders");

            //migrationBuilder.DropIndex(
            //    name: "IX_OrderDetails_OrderId",
            //    table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DrinkId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "SweetId",
                table: "Orders",
                newName: "OrderDetailId");

            migrationBuilder.RenameColumn(
              name: "OrderId",
              table: "OrderDetails",
              newName: "UserId"
              );

            migrationBuilder.AddPrimaryKey("PK_OrderDetails", "OrderDetails", "OrderDetailId");

            migrationBuilder.AddPrimaryKey("PK_Orders", "Orders", "OrderId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_Orders_SweetId",
            //    table: "Orders",
            //    newName: "IX_Orders_OrderDetailId");

          

            
            migrationBuilder.AddColumn<DateTime>(
                name: "MomentOfOrder",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "TotalAmount",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<byte>(
                name: "Count",
                table: "OrderDetails",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "DrinkId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FoodId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "OrderDetails",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "SweetId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_DrinkId",
                table: "OrderDetails",
                column: "DrinkId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_FoodId",
                table: "OrderDetails",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_MenuId",
                table: "OrderDetails",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_SweetId",
                table: "OrderDetails",
                column: "SweetId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Drinks_DrinkId",
                table: "OrderDetails",
                column: "DrinkId",
                principalTable: "Drinks",
                principalColumn: "DrinkId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Foods_FoodId",
                table: "OrderDetails",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "FoodId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Menus_MenuId",
                table: "OrderDetails",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Sweets_SweetId",
                table: "OrderDetails",
                column: "SweetId",
                principalTable: "Sweets",
                principalColumn: "SweetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderDetails_OrderDetailId",
                table: "Orders",
                column: "OrderDetailId",
                principalTable: "OrderDetails",
                principalColumn: "OrderDetailId",
                onDelete: ReferentialAction.Cascade);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Drinks_DrinkId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Foods_FoodId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Menus_MenuId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Sweets_SweetId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderDetails_OrderDetailId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_DrinkId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_FoodId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_MenuId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_SweetId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "MomentOfOrder",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "DrinkId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "SweetId",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "OrderDetailId",
                table: "Orders",
                newName: "SweetId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OrderDetailId",
                table: "Orders",
                newName: "IX_Orders_SweetId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "OrderDetails",
                newName: "OrderId");

            migrationBuilder.AddColumn<byte>(
                name: "Count",
                table: "Orders",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "DrinkId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FoodId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "OrderDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_DrinkId",
            //    table: "Orders",
            //    column: "DrinkId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_FoodId",
            //    table: "Orders",
            //    column: "FoodId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_MenuId",
            //    table: "Orders",
            //    column: "MenuId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderDetails_OrderId",
            //    table: "OrderDetails",
            //    column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Drinks_DrinkId",
                table: "Orders",
                column: "DrinkId",
                principalTable: "Drinks",
                principalColumn: "DrinkId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Foods_FoodId",
                table: "Orders",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "FoodId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Menus_MenuId",
                table: "Orders",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Sweets_SweetId",
                table: "Orders",
                column: "SweetId",
                principalTable: "Sweets",
                principalColumn: "SweetId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
