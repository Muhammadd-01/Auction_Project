using System.ComponentModel.DataAnnotations;

namespace Auction_Project.models
{
    public class Notifications
    {
        [Key]
        public int NotificationId { get; set; }

        public string Notification { get; set; }
    }
}
