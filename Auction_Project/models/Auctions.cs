    using System.ComponentModel.DataAnnotations;

    namespace Auction_Project.models
    {
        public class Auctions
        {
            [Key]
            public int Id { get; set; }

            [Required]
            public string Title { get; set; }

            public string Description { get; set; } // Item details

            [Required]
            public decimal StartingPrice { get; set; } // Base bid

            public decimal? CurrentHighestBid { get; set; } // Gets updated as people bid

            public DateTime StartTime { get; set; }

            public DateTime EndTime { get; set; }

            public bool IsActive { get; set; } = true; // Auction still going on?

            public string ImageUrl { get; set; } // Optional image

        }
    }
