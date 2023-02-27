using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Petshop.Infra.Migrations
{
    public partial class addimageetodbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagee_Products_ProductId",
                table: "Imagee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Imagee",
                table: "Imagee");

            migrationBuilder.RenameTable(
                name: "Imagee",
                newName: "Imagees");

            migrationBuilder.RenameIndex(
                name: "IX_Imagee_ProductId",
                table: "Imagees",
                newName: "IX_Imagees_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Imagees",
                table: "Imagees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagees_Products_ProductId",
                table: "Imagees",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagees_Products_ProductId",
                table: "Imagees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Imagees",
                table: "Imagees");

            migrationBuilder.RenameTable(
                name: "Imagees",
                newName: "Imagee");

            migrationBuilder.RenameIndex(
                name: "IX_Imagees_ProductId",
                table: "Imagee",
                newName: "IX_Imagee_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Imagee",
                table: "Imagee",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagee_Products_ProductId",
                table: "Imagee",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
