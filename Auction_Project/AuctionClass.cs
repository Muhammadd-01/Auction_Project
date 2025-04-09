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
    }
}
