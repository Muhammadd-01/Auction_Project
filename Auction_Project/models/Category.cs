using System.ComponentModel.DataAnnotations;



namespace Auction_Project.models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
