using System.ComponentModel.DataAnnotations;

namespace Auction_Project.models
{
    public class BookCategories
    {
        [Key]
        public int Id { get; set; }
       public string CategoryName { get; set; }

        //public int BookId { get; set; }
        //public List<Books> Books { get; set; }
    }
}
