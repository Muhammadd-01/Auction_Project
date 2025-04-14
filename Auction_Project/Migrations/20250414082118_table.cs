using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction_Project.Migrations
{
    /// <inheritdoc />
    public partial class table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Seller_tbl_Users_UserId",
                table: "tbl_Seller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Seller",
                table: "tbl_Seller");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Seller_UserId",
                table: "tbl_Seller");

            migrationBuilder.RenameTable(
                name: "tbl_Seller",
                newName: "Seller");

            migrationBuilder.RenameColumn(
                name: "SellerID",
                table: "tbl_Furnitures",
                newName: "SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_Furnitures_SellerID",
                table: "tbl_Furnitures",
                newName: "IX_tbl_Furnitures_SellerId");

            migrationBuilder.RenameColumn(
                name: "SellerID",
                table: "tbl_Electronics",
                newName: "SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_Electronics_SellerID",
                table: "tbl_Electronics",
                newName: "IX_tbl_Electronics_SellerId");

            migrationBuilder.RenameColumn(
                name: "SellerID",
                table: "tbl_Books",
                newName: "SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_Books_SellerID",
                table: "tbl_Books",
                newName: "IX_tbl_Books_SellerId");

            migrationBuilder.AlterColumn<int>(
                name: "SellerId",
                table: "tbl_Furnitures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SellerId",
                table: "tbl_Electronics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SellerId",
                table: "tbl_Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Usersid",
                table: "Seller",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seller",
                table: "Seller",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Seller_Usersid",
                table: "Seller",
                column: "Usersid");

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_tbl_Users_Usersid",
                table: "Seller",
                column: "Usersid",
                principalTable: "tbl_Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_tbl_Users_Usersid",
                table: "Seller");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Books_Seller_SellerId",
                table: "tbl_Books");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Electronics_Seller_SellerId",
                table: "tbl_Electronics");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Furnitures_Seller_SellerId",
                table: "tbl_Furnitures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seller",
                table: "Seller");

            migrationBuilder.DropIndex(
                name: "IX_Seller_Usersid",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "Usersid",
                table: "Seller");

            migrationBuilder.RenameTable(
                name: "Seller",
                newName: "tbl_Seller");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "tbl_Furnitures",
                newName: "SellerID");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_Furnitures_SellerId",
                table: "tbl_Furnitures",
                newName: "IX_tbl_Furnitures_SellerID");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "tbl_Electronics",
                newName: "SellerID");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_Electronics_SellerId",
                table: "tbl_Electronics",
                newName: "IX_tbl_Electronics_SellerID");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "tbl_Books",
                newName: "SellerID");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_Books_SellerId",
                table: "tbl_Books",
                newName: "IX_tbl_Books_SellerID");

            migrationBuilder.AlterColumn<int>(
                name: "SellerID",
                table: "tbl_Furnitures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SellerID",
                table: "tbl_Electronics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SellerID",
                table: "tbl_Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Seller",
                table: "tbl_Seller",
                column: "SellerId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Seller_tbl_Users_UserId",
                table: "tbl_Seller",
                column: "UserId",
                principalTable: "tbl_Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
