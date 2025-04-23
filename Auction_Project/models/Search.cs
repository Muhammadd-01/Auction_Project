using System.Collections.Generic;
namespace Auction_Project.models
{
    public class Search
    {
        public string Query { get; set; }

        // Results
        public List<Books> BooksResults { get; set; } = new List<Books>();
        public List<Electronics> ElectronicsResults { get; set; } = new List<Electronics>();
        public List<Furnitures> FurnituresResults { get; set; } = new List<Furnitures>();

        // Optional: for user to choose which category to search
        public string SelectedCategory { get; set; }
    }
}
