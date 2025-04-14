using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auction_Project.models
{
    public class FurnitureCategories
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public int FurnituresId { get; set; }
        public List<Furnitures> Furnitures { get; set; }
    }
}
