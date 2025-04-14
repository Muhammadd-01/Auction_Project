using System.ComponentModel.DataAnnotations;

namespace Auction_Project.models
{
    public class ElectronicCategories
    {

        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }

    }
}
