using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction_Project.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Books_Seller_SellerId",
                table: "tbl_Books");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Electronics_Seller_SellerId",
                table: "tbl_Electronics");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Furnitures_Seller_SellerId",
                table: "tbl_Furnitures");

            migrationBuilder.DropTable(
                name: "Seller");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Furnitures_SellerId",
                table: "tbl_Furnitures");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Electronics_SellerId",
                table: "tbl_Electronics");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Books_SellerId",
                table: "tbl_Books");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "tbl_Furnitures");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "tbl_Electronics");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "tbl_Books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "tbl_Furnitures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "tbl_Electronics",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "tbl_Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Seller",
                columns: table => new
                {
                    SellerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usersid = table.Column<int>(type: "int", nullable: false),
                    SellerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seller", x => x.SellerId);
                    table.ForeignKey(
                        name: "FK_Seller_tbl_Users_Usersid",
                        column: x => x.Usersid,
                        principalTable: "tbl_Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Furnitures_SellerId",
                table: "tbl_Furnitures",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Electronics_SellerId",
                table: "tbl_Electronics",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Books_SellerId",
                table: "tbl_Books",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Seller_Usersid",
                table: "Seller",
                column: "Usersid");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Books_Seller_SellerId",
                table: "tbl_Books",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Electronics_Seller_SellerId",
                table: "tbl_Electronics",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Furnitures_Seller_SellerId",
                table: "tbl_Furnitures",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "SellerId");
        }
    }
}
