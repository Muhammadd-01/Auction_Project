using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auction_Project.models
{
    public class Furnitures
    {
        [Key]
        public int ItemID { get; set; }

        [MaxLength(255)]
        public string? Image { get; set; } = "/images/default-item.jpg"; // default image path

        [Required]
        [MaxLength(100)]
        public string ItemTitle { get; set; }

        [MaxLength(4000)]
        public string ItemDescription { get; set; }

        [Column(TypeName = "char(1)")]
        [Required]
        public char BidStatus { get; set; } = 'A'; // Default value

        [Required]
        [DataType(DataType.Date)]
        public DateTime BidStartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BidEndDate { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? BidIncrement { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? MinimumBid { get; set; }

        [Required]
        [MaxLength(100)]
        public string Subcategory { get; set; } // <-- ADD THIS LINE

        // Foreign key to User
        public int SellerID { get; set; }
        public Seller Seller { get; set; }

        //public int CategoryID { get; set; }
        //public BookCategories BookCategories { get; set; }
    }
}
