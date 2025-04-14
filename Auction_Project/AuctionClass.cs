using Microsoft.EntityFrameworkCore;
using Auction_Project.models;

namespace Auction_Project
{
    public class AuctionClass: DbContext

    {
        public AuctionClass(DbContextOptions<AuctionClass> options) : base(options)
        {

        }

       public DbSet<Users> tbl_Users { get; set; }
       public DbSet<Ratings> tbl_Ratings { get; set; }
        public DbSet<BookCategories> tbl_BookCategories { get; set; }
        public DbSet<ElectronicCategories> tbl_ElectronicCategories { get; set; }
        public DbSet<FurnitureCategories> tbl_FurnitureCategories { get; set; }

        public DbSet<Electronics> tbl_Electronics { get; set; }


        public DbSet<Furnitures> tbl_Furnitures { get; set; }
        //public DbSet<Books> tbl_Books { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Books>().HasOne(b=>b.Users).WithMany(u=>u.Books).HasForeignKey(b=>b.UserID);
        //}



    }
}
