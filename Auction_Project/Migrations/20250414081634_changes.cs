﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction_Project.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_BookCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
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
                    CategoryID = table.Column<int>(type: "int", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "tbl_Electronics",
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
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Electronics", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_tbl_Electronics_tbl_ElectronicCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "tbl_ElectronicCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Furnitures",
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
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Furnitures", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_tbl_Furnitures_tbl_FurnitureCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "tbl_FurnitureCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Books_CategoryID",
                table: "tbl_Books",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Electronics_CategoryID",
                table: "tbl_Electronics",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Furnitures_CategoryID",
                table: "tbl_Furnitures",
                column: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Books");

            migrationBuilder.DropTable(
                name: "tbl_Electronics");

            migrationBuilder.DropTable(
                name: "tbl_Furnitures");

            migrationBuilder.DropTable(
                name: "tbl_BookCategories");

            migrationBuilder.DropTable(
                name: "tbl_ElectronicCategories");

            migrationBuilder.DropTable(
                name: "tbl_FurnitureCategories");
        }
    }
}
