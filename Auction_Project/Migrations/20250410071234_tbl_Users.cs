using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction_Project.Migrations
{
    /// <inheritdoc />
    public partial class tbl_Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "tbl_Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "tbl_Users");
        }
    }
}
