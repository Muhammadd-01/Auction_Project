using System.ComponentModel.DataAnnotations;



namespace Auction_Project.models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
