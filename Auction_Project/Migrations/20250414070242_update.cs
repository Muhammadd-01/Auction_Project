using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction_Project.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "tbl_FurnitureCategories",
                newName: "FurnituresId");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "tbl_ElectronicCategories",
                newName: "ElectronicsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FurnituresId",
                table: "tbl_FurnitureCategories",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "ElectronicsId",
                table: "tbl_ElectronicCategories",
                newName: "BookId");
        }
    }
}
