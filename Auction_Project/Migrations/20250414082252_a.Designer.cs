﻿// <auto-generated />
using System;
using Auction_Project;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Auction_Project.Migrations
{
    [DbContext(typeof(AuctionClass))]
    [Migration("20250414082252_a")]
    partial class a
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Auction_Project.models.Auctions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("CurrentHighestBid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("StartingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbl_Auctions");
                });

            modelBuilder.Entity("Auction_Project.models.BookCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbl_BookCategories");
                });

            modelBuilder.Entity("Auction_Project.models.Books", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemID"));

                    b.Property<DateTime>("BidEndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("BidIncrement")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("BidStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BidStatus")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ItemDescription")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("ItemTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("MinimumBid")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("ItemID");

                    b.HasIndex("CategoryID");

                    b.ToTable("tbl_Books");
                });

            modelBuilder.Entity("Auction_Project.models.ElectronicCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ElectronicsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tbl_ElectronicCategories");
                });

            modelBuilder.Entity("Auction_Project.models.Electronics", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemID"));

                    b.Property<DateTime>("BidEndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("BidIncrement")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("BidStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BidStatus")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ItemDescription")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("ItemTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("MinimumBid")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("ItemID");

                    b.HasIndex("CategoryID");

                    b.ToTable("tbl_Electronics");
                });

            modelBuilder.Entity("Auction_Project.models.FurnitureCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FurnituresId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tbl_FurnitureCategories");
                });

            modelBuilder.Entity("Auction_Project.models.Furnitures", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemID"));

                    b.Property<DateTime>("BidEndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("BidIncrement")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("BidStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BidStatus")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ItemDescription")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("ItemTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("MinimumBid")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("ItemID");

                    b.HasIndex("CategoryID");

                    b.ToTable("tbl_Furnitures");
                });

            modelBuilder.Entity("Auction_Project.models.Ratings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tbl_Ratings");
                });

            modelBuilder.Entity("Auction_Project.models.Users", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("tbl_Users");
                });

            modelBuilder.Entity("Auction_Project.models.Books", b =>
                {
                    b.HasOne("Auction_Project.models.BookCategories", "BookCategories")
                        .WithMany("Books")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookCategories");
                });

            modelBuilder.Entity("Auction_Project.models.Electronics", b =>
                {
                    b.HasOne("Auction_Project.models.ElectronicCategories", "ElectronicCategories")
                        .WithMany("Electronics")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ElectronicCategories");
                });

            modelBuilder.Entity("Auction_Project.models.Furnitures", b =>
                {
                    b.HasOne("Auction_Project.models.FurnitureCategories", "FurnitureCategories")
                        .WithMany("Furnitures")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FurnitureCategories");
                });

            modelBuilder.Entity("Auction_Project.models.BookCategories", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Auction_Project.models.ElectronicCategories", b =>
                {
                    b.Navigation("Electronics");
                });

            modelBuilder.Entity("Auction_Project.models.FurnitureCategories", b =>
                {
                    b.Navigation("Furnitures");
                });
#pragma warning restore 612, 618
        }
    }
}
