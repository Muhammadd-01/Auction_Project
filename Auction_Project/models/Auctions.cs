    using System.ComponentModel.DataAnnotations;

    namespace Auction_Project.models
    {
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Auction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; } // Item details

        [Required]
        public decimal StartingPrice { get; set; } // Base bid

        public decimal CurrentHighestBid { get; set; } // Gets updated as people bid

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool IsActive { get; set; } = true; // Auction still going on?

        //public string ImageUrl { get; set; }

        // Foreign keys to Book, Electronics, Furniture (nullable, since only one will be used)

        public int SellerId { get; set; }

        public Seller Seller { get; set; }
        public int UserId { get; set; }
        public Users Users { get; set; }
        public int? BookId { get; set; }
        public Books Books { get; set; }

        public int? ElectronicsId { get; set; }
        public Electronics Electronics { get; set; }

        public int? FurnitureId { get; set; }
        public Furnitures Furnitures { get; set; }
    }

}
