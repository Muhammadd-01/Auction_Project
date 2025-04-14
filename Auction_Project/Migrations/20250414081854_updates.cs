using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction_Project.Migrations
{
    /// <inheritdoc />
    public partial class updates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SellerID",
                table: "tbl_Furnitures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SellerID",
                table: "tbl_Electronics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SellerID",
                table: "tbl_Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tbl_Seller",
                columns: table => new
                {
                    SellerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Seller", x => x.SellerId);
                    table.ForeignKey(
                        name: "FK_tbl_Seller_tbl_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "tbl_Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Furnitures_SellerID",
                table: "tbl_Furnitures",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Electronics_SellerID",
                table: "tbl_Electronics",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Books_SellerID",
                table: "tbl_Books",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Seller_UserId",
                table: "tbl_Seller",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Books_tbl_Seller_SellerID",
                table: "tbl_Books",
                column: "SellerID",
                principalTable: "tbl_Seller",
                principalColumn: "SellerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Electronics_tbl_Seller_SellerID",
                table: "tbl_Electronics",
                column: "SellerID",
                principalTable: "tbl_Seller",
                principalColumn: "SellerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Furnitures_tbl_Seller_SellerID",
                table: "tbl_Furnitures",
                column: "SellerID",
                principalTable: "tbl_Seller",
                principalColumn: "SellerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Books_tbl_Seller_SellerID",
                table: "tbl_Books");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Electronics_tbl_Seller_SellerID",
                table: "tbl_Electronics");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Furnitures_tbl_Seller_SellerID",
                table: "tbl_Furnitures");

            migrationBuilder.DropTable(
                name: "tbl_Seller");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Furnitures_SellerID",
                table: "tbl_Furnitures");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Electronics_SellerID",
                table: "tbl_Electronics");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Books_SellerID",
                table: "tbl_Books");

            migrationBuilder.DropColumn(
                name: "SellerID",
                table: "tbl_Furnitures");

            migrationBuilder.DropColumn(
                name: "SellerID",
                table: "tbl_Electronics");

            migrationBuilder.DropColumn(
                name: "SellerID",
                table: "tbl_Books");
        }
    }
}
