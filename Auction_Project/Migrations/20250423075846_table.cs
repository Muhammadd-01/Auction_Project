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
                name: "FK_tbl_Users_tbl_Users_Usersid",
                table: "tbl_Users");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Users_Usersid",
                table: "tbl_Users");

            migrationBuilder.DropColumn(
                name: "Usersid",
                table: "tbl_Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Usersid",
                table: "tbl_Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Users_Usersid",
                table: "tbl_Users",
                column: "Usersid");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Users_tbl_Users_Usersid",
                table: "tbl_Users",
                column: "Usersid",
                principalTable: "tbl_Users",
                principalColumn: "id");
        }
    }
}
