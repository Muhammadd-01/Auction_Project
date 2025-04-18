using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auction_Project.models
{
    public class Electronics
    {
        [Key]
  
        public int ItemID { get; set; }
        public string ItemTitle { get; set; }
        public string Electronic_cover { get; set; }
        public string SubCategory { get; set; }
        public string ItemDescription { get; set; }
        public decimal MinimumBid { get; set; }
        public string BidStatus { get; set; }
        public DateTime BidStartDate { get; set; }
        public DateTime BidEndDate { get; set; }
        public decimal BidIncrement { get; set; }
        public int SellerID { get; set; }
        public Seller Seller { get; set; }
        public List<Auction> Auctions { get; set; }

    }
}
