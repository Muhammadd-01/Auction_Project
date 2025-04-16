using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction_Project.Migrations
{
    /// <inheritdoc />
    public partial class b : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subcategory",
                table: "tbl_Books",
                newName: "SubCategory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubCategory",
                table: "tbl_Books",
                newName: "Subcategory");
        }
    }
}
