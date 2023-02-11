using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Petshop.Infra.Migrations
{
    public partial class addproptoorderInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderInfos_Orders_OrderId",
                table: "OrderInfos");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderInfos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderInfos_Orders_OrderId",
                table: "OrderInfos",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderInfos_Orders_OrderId",
                table: "OrderInfos");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderInfos_Orders_OrderId",
                table: "OrderInfos",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
