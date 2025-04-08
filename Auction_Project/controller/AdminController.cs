using Microsoft.AspNetCore.Mvc;

namespace Auction_Project.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult ManageUsers()
        {
            return View();
        }
        public IActionResult AddUsers()
        {
            return View();
        }
        public IActionResult ManageItems()
        {
            return View();
        }
        public IActionResult AddItems()
        {
            return View();
        }
        public IActionResult ManageCategories()
        {
            return View();
        }
        public IActionResult AddCategories()
        {
            return View();
        }
        public IActionResult ManageAuctions()
        {
            return View();
        }

        public IActionResult BiddingHistory()
        {
            return View();
        }

        public IActionResult Ratings()
        {
            return View();
        }

        public IActionResult Notifications()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }
    }
}
