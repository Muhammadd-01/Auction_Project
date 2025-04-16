using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction_Project.Migrations
{
    /// <inheritdoc />
    public partial class c : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Books_tbl_BookCategories_CategoryID",
                table: "tbl_Books");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Electronics_tbl_ElectronicCategories_CategoryID",
                table: "tbl_Electronics");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Furnitures_tbl_FurnitureCategories_CategoryID",
                table: "tbl_Furnitures");

            migrationBuilder.DropTable(
                name: "tbl_BookCategories");

            migrationBuilder.DropTable(
                name: "tbl_ElectronicCategories");

            migrationBuilder.DropTable(
                name: "tbl_FurnitureCategories");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Furnitures_CategoryID",
                table: "tbl_Furnitures");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Electronics_CategoryID",
                table: "tbl_Electronics");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Books_CategoryID",
                table: "tbl_Books");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "tbl_Furnitures");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "tbl_Electronics");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "tbl_Books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "tbl_Furnitures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "tbl_Electronics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "tbl_Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tbl_BookCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_BookCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ElectronicCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElectronicsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ElectronicCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_FurnitureCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FurnituresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_FurnitureCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Furnitures_CategoryID",
                table: "tbl_Furnitures",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Electronics_CategoryID",
                table: "tbl_Electronics",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Books_CategoryID",
                table: "tbl_Books",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Books_tbl_BookCategories_CategoryID",
                table: "tbl_Books",
                column: "CategoryID",
                principalTable: "tbl_BookCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Electronics_tbl_ElectronicCategories_CategoryID",
                table: "tbl_Electronics",
                column: "CategoryID",
                principalTable: "tbl_ElectronicCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Furnitures_tbl_FurnitureCategories_CategoryID",
                table: "tbl_Furnitures",
                column: "CategoryID",
                principalTable: "tbl_FurnitureCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
