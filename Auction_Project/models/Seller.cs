namespace Auction_Project.models
{
    public class Seller
    {
        public int SellerId { get; set; }

        public string SellerName { get; set; }

        public string SellerEmail { get; set; }

        public int UserId { get; set; }

        public Users Users { get; set; }

        public List<Books> Books { get; set; }
        public List<Electronics> Electronics { get; set; }
        public List<Furnitures> Furnitures { get; set; }
    }
}
