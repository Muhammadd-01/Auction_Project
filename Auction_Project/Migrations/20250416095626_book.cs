using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction_Project.Migrations
{
    /// <inheritdoc />
    public partial class book : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Books",
                table: "tbl_Books");

            migrationBuilder.AlterColumn<string>(
                name: "ItemTitle",
                table: "tbl_Books",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ItemID",
                table: "tbl_Books",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Books",
                table: "tbl_Books",
                column: "ItemID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Books",
                table: "tbl_Books");

            migrationBuilder.DropColumn(
                name: "ItemID",
                table: "tbl_Books");

            migrationBuilder.AlterColumn<string>(
                name: "ItemTitle",
                table: "tbl_Books",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Books",
                table: "tbl_Books",
                column: "ItemTitle");
        }
    }
}
