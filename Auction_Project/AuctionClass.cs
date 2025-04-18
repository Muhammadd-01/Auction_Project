using Microsoft.EntityFrameworkCore;
using Auction_Project.models;
using System.Reflection.Emit;

namespace Auction_Project
{
    public class AuctionClass: DbContext

    {
        public AuctionClass(DbContextOptions<AuctionClass> options) : base(options)
        {

        }

       public DbSet<Users> tbl_Users { get; set; }


        //public DbSet<Ratings> tbl_Ratings { get; set; }
       public DbSet<Seller> tbl_Seller { get; set; }



        public DbSet<Auction> tbl_Auctions { get; set; }
        //public DbSet<BookCategories> tbl_BookCategories { get; set; }
        //public DbSet<ElectronicCategories> tbl_ElectronicCategories { get; set; }
        //public DbSet<FurnitureCategories> tbl_FurnitureCategories { get; set; }

        public DbSet<Electronics> tbl_Electronics { get; set; }
        public DbSet<Category> tbl_Categories { get; set; }


        public DbSet<Furnitures> tbl_Furnitures { get; set; }
        public DbSet<Books> tbl_Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>().HasOne(b=>b.Seller).WithMany(u=>u.Books).HasForeignKey(b=>b.SellerID);
            //modelBuilder.Entity<Books>().HasOne(b=>b.BookCategories).WithMany(u=>u.Books).HasForeignKey(b=>b.CategoryID);
            modelBuilder.Entity<Electronics>().HasOne(e => e.Seller).WithMany(s => s.Electronics).HasForeignKey(e => e.SellerID);
            //modelBuilder.Entity<Electronics>().HasOne(e => e.ElectronicCategories).WithMany(u => u.Electronics).HasForeignKey(e => e.CategoryID);
            modelBuilder.Entity<Furnitures>().HasOne(f => f.Seller).WithMany(u => u.Furnitures).HasForeignKey(f => f.SellerID);
            //modelBuilder.Entity<Furnitures>().HasOne(f => f.FurnitureCategories).WithMany(u => u.Furnitures).HasForeignKey(b => b.CategoryID);
            modelBuilder.Entity<Seller>().HasOne(s => s.Users).WithMany(u => u.Seller).HasForeignKey(s => s.UserId);
            modelBuilder.Entity<Auction>().HasOne(a => a.Books).WithMany().HasForeignKey(a => a.BookId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Auction>().HasOne(a => a.Electronics).WithMany().HasForeignKey(a => a.ElectronicsId).OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Auction>().HasOne(a => a.Furnitures).WithMany().HasForeignKey(a => a.FurnitureId).OnDelete(DeleteBehavior.Restrict);

        }



    }
}
