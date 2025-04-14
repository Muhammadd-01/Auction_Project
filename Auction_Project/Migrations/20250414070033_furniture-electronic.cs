using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction_Project.Migrations
{
    /// <inheritdoc />
    public partial class furnitureelectronic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Books_tbl_Users_Usersid",
                table: "tbl_Books");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Books_Usersid",
                table: "tbl_Books");

            migrationBuilder.DropColumn(
                name: "Usersid",
                table: "tbl_Books");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "tbl_Furnitures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SellerID",
                table: "tbl_Furnitures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "tbl_FurnitureCategories",
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
                name: "SellerID",
                table: "tbl_Electronics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "tbl_ElectronicCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Furnitures_CategoryID",
                table: "tbl_Furnitures",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Furnitures_SellerID",
                table: "tbl_Furnitures",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Electronics_CategoryID",
                table: "tbl_Electronics",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Electronics_SellerID",
                table: "tbl_Electronics",
                column: "SellerID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Electronics_tbl_ElectronicCategories_CategoryID",
                table: "tbl_Electronics",
                column: "CategoryID",
                principalTable: "tbl_ElectronicCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Electronics_tbl_Seller_SellerID",
                table: "tbl_Electronics",
                column: "SellerID",
                principalTable: "tbl_Seller",
                principalColumn: "SellerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Furnitures_tbl_FurnitureCategories_CategoryID",
                table: "tbl_Furnitures",
                column: "CategoryID",
                principalTable: "tbl_FurnitureCategories",
                principalColumn: "Id",
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
                name: "FK_tbl_Electronics_tbl_ElectronicCategories_CategoryID",
                table: "tbl_Electronics");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Electronics_tbl_Seller_SellerID",
                table: "tbl_Electronics");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Furnitures_tbl_FurnitureCategories_CategoryID",
                table: "tbl_Furnitures");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Furnitures_tbl_Seller_SellerID",
                table: "tbl_Furnitures");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Furnitures_CategoryID",
                table: "tbl_Furnitures");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Furnitures_SellerID",
                table: "tbl_Furnitures");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Electronics_CategoryID",
                table: "tbl_Electronics");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Electronics_SellerID",
                table: "tbl_Electronics");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "tbl_Furnitures");

            migrationBuilder.DropColumn(
                name: "SellerID",
                table: "tbl_Furnitures");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "tbl_FurnitureCategories");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "tbl_Electronics");

            migrationBuilder.DropColumn(
                name: "SellerID",
                table: "tbl_Electronics");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "tbl_ElectronicCategories");

            migrationBuilder.AddColumn<int>(
                name: "Usersid",
                table: "tbl_Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Books_Usersid",
                table: "tbl_Books",
                column: "Usersid");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Books_tbl_Users_Usersid",
                table: "tbl_Books",
                column: "Usersid",
                principalTable: "tbl_Users",
                principalColumn: "id");
        }
    }
}
