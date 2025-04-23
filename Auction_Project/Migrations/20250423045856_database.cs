using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction_Project.Migrations
{
    /// <inheritdoc />
    public partial class database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usersid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_Users_tbl_Users_Usersid",
                        column: x => x.Usersid,
                        principalTable: "tbl_Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_Seller",
                columns: table => new
                {
                    SellerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellerBio = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "tbl_Books",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    book_cover = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumBid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BidStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BidStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BidEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BidIncrement = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Books", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_tbl_Books_tbl_Seller_SellerID",
                        column: x => x.SellerID,
                        principalTable: "tbl_Seller",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Electronics",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Electronic_cover = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumBid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BidStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BidStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BidEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BidIncrement = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Electronics", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_tbl_Electronics_tbl_Seller_SellerID",
                        column: x => x.SellerID,
                        principalTable: "tbl_Seller",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Furnitures",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Furniture_cover = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumBid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BidStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BidStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BidEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BidIncrement = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Furnitures", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_tbl_Furnitures_tbl_Seller_SellerID",
                        column: x => x.SellerID,
                        principalTable: "tbl_Seller",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Auctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentHighestBid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: true),
                    ElectronicsId = table.Column<int>(type: "int", nullable: true),
                    FurnitureId = table.Column<int>(type: "int", nullable: true),
                    BooksItemID = table.Column<int>(type: "int", nullable: true),
                    ElectronicsItemID = table.Column<int>(type: "int", nullable: true),
                    FurnituresItemID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Auctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Auctions_tbl_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "tbl_Books",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Auctions_tbl_Books_BooksItemID",
                        column: x => x.BooksItemID,
                        principalTable: "tbl_Books",
                        principalColumn: "ItemID");
                    table.ForeignKey(
                        name: "FK_tbl_Auctions_tbl_Electronics_ElectronicsId",
                        column: x => x.ElectronicsId,
                        principalTable: "tbl_Electronics",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Auctions_tbl_Electronics_ElectronicsItemID",
                        column: x => x.ElectronicsItemID,
                        principalTable: "tbl_Electronics",
                        principalColumn: "ItemID");
                    table.ForeignKey(
                        name: "FK_tbl_Auctions_tbl_Furnitures_FurnitureId",
                        column: x => x.FurnitureId,
                        principalTable: "tbl_Furnitures",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Auctions_tbl_Furnitures_FurnituresItemID",
                        column: x => x.FurnituresItemID,
                        principalTable: "tbl_Furnitures",
                        principalColumn: "ItemID");
                    table.ForeignKey(
                        name: "FK_tbl_Auctions_tbl_Seller_SellerId",
                        column: x => x.SellerId,
                        principalTable: "tbl_Seller",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Auctions_tbl_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "tbl_Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Auctions_BookId",
                table: "tbl_Auctions",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Auctions_BooksItemID",
                table: "tbl_Auctions",
                column: "BooksItemID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Auctions_ElectronicsId",
                table: "tbl_Auctions",
                column: "ElectronicsId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Auctions_ElectronicsItemID",
                table: "tbl_Auctions",
                column: "ElectronicsItemID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Auctions_FurnitureId",
                table: "tbl_Auctions",
                column: "FurnitureId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Auctions_FurnituresItemID",
                table: "tbl_Auctions",
                column: "FurnituresItemID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Auctions_SellerId",
                table: "tbl_Auctions",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Auctions_UserId",
                table: "tbl_Auctions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Books_SellerID",
                table: "tbl_Books",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Electronics_SellerID",
                table: "tbl_Electronics",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Furnitures_SellerID",
                table: "tbl_Furnitures",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Seller_UserId",
                table: "tbl_Seller",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Users_Usersid",
                table: "tbl_Users",
                column: "Usersid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Auctions");

            migrationBuilder.DropTable(
                name: "tbl_Categories");

            migrationBuilder.DropTable(
                name: "tbl_Books");

            migrationBuilder.DropTable(
                name: "tbl_Electronics");

            migrationBuilder.DropTable(
                name: "tbl_Furnitures");

            migrationBuilder.DropTable(
                name: "tbl_Seller");

            migrationBuilder.DropTable(
                name: "tbl_Users");
        }
    }
}
