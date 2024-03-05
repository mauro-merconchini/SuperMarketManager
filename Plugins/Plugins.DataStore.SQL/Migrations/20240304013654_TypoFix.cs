using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plugins.DataStore.SQL.Migrations
{
    /// <inheritdoc />
    public partial class TypoFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proeducts_Categories_CategoryId",
                table: "Proeducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proeducts",
                table: "Proeducts");

            migrationBuilder.RenameTable(
                name: "Proeducts",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_Proeducts_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Proeducts");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Proeducts",
                newName: "IX_Proeducts_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proeducts",
                table: "Proeducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Proeducts_Categories_CategoryId",
                table: "Proeducts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
