using System.ComponentModel.DataAnnotations;

namespace Auction_Project.models
{
    public class Ratings
    {
        public int Id { get; set; }

        [Range(1, 5)]
        public int Score { get; set; } // 1 to 5 stars



    }
}
