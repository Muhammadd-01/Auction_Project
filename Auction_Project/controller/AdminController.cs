using Microsoft.AspNetCore.Mvc;
using Auction_Project.models;
using System.Linq;

namespace Auction_Project.Controllers
{
    public class AdminController : Controller
    {
        private readonly AuctionClass _context;

        public AdminController(AuctionClass context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult ManageUsers()
        {
            var users = _context.tbl_Users.ToList(); // Fetch users from SQL Server
            return View(users);
        }
        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.tbl_Users.FirstOrDefault(u => u.id == id);
            if (user != null)
            {
                _context.tbl_Users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction("ManageUsers"); // Redirect back to the user management page after deletion
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

        public IActionResult Books()
        {
            return View();
        }

        public IActionResult Furnitures()
        {
            return View();
        }

        public IActionResult Electronics()
        {
            return View();
        }

        public IActionResult Page404()
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
    }
}
