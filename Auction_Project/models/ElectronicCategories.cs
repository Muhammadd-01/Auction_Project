using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auction_Project.models
{
    public class ElectronicCategories
    {

        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public int ElectronicsId { get; set; }
        public List<Electronics> Electronics { get; set; }
    }
}
