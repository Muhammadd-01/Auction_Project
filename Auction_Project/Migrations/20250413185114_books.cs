using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction_Project.Migrations
{
    /// <inheritdoc />
    public partial class books : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubCategory",
                table: "tbl_Books");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "tbl_Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Books_CategoryID",
                table: "tbl_Books",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Books_BookCategories_CategoryID",
                table: "tbl_Books",
                column: "CategoryID",
                principalTable: "BookCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Books_BookCategories_CategoryID",
                table: "tbl_Books");

            migrationBuilder.DropTable(
                name: "BookCategories");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Books_CategoryID",
                table: "tbl_Books");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "tbl_Books");

            migrationBuilder.AddColumn<string>(
                name: "SubCategory",
                table: "tbl_Books",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
