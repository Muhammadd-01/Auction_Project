using Microsoft.EntityFrameworkCore;


namespace Auction_Project
{
    public class AuctionClass: DbContext

    {
        public AuctionClass(DbContextOptions<AuctionClass> options) : base(options)
        {

        }
    }
}
