using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Petshop.Infra.Migrations
{
    public partial class generateaddproductpage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "قلاده", null, "pro01", 10000000 },
                    { 2, 2, "غذای خشک", null, "pro02", 200000 },
                    { 3, 3, "حوله", null, "pro03", 30000 },
                    { 4, 2, "ظرف آب", null, "pro04", 800000 },
                    { 5, 3, "کنسرو", null, "pro05", 30000 },
                    { 6, 3, "شامپو", null, "pro06", 30000 },
                    { 7, 1, "کفش", null, "pro07", 3000000 }
                });
        }
    }
}
