using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction_Project.Migrations
{
    /// <inheritdoc />
    public partial class tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "tbl_Seller",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "tbl_BookCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tbl_Books",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ItemTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    BidStatus = table.Column<string>(type: "char(1)", nullable: false),
                    BidStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BidEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BidIncrement = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    MinimumBid = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    SellerID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Usersid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Books", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_tbl_Books_tbl_BookCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "tbl_BookCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Books_tbl_Seller_SellerID",
                        column: x => x.SellerID,
                        principalTable: "tbl_Seller",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Books_tbl_Users_Usersid",
                        column: x => x.Usersid,
                        principalTable: "tbl_Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Seller_UserId",
                table: "tbl_Seller",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Books_CategoryID",
                table: "tbl_Books",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Books_SellerID",
                table: "tbl_Books",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Books_Usersid",
                table: "tbl_Books",
                column: "Usersid");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Seller_tbl_Users_UserId",
                table: "tbl_Seller",
                column: "UserId",
                principalTable: "tbl_Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Seller_tbl_Users_UserId",
                table: "tbl_Seller");

            migrationBuilder.DropTable(
                name: "tbl_Books");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Seller_UserId",
                table: "tbl_Seller");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tbl_Seller");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "tbl_BookCategories");
        }
    }
}
