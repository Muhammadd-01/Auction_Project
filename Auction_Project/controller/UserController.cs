using Microsoft.AspNetCore.Mvc;
using Auction_Project.models;
namespace Auction_Project.controller
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Searchresult()
        {
            return View();
        }
        public IActionResult Items()
        {
            return View();
        }

        public IActionResult Bidding()
        {
            return View();
        }
        public IActionResult Bidder()
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
        public IActionResult Books()
        {
            return View();
        }
        public IActionResult Sell()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Notifications()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        private readonly AuctionClass _context;

        // Constructor
        public UserController(AuctionClass context)
        {
            _context = context;
        }

        // GET: User/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: User/Register
        [HttpPost]
        public IActionResult Register(Users user)
        {
            if (ModelState.IsValid)
            {
                _context.tbl_Users.Add(user);
                _context.SaveChanges();

                // Check if the newly registered user is "admin123"
                if (user.email == "admin@gmail.com" && user.password == "12345678") // You can change this condition as needed
                {
                    // Redirect to the Admin Dashboard
                    return RedirectToAction("Dashboard", "Admin"); // This will redirect to the Admin Controller's Dashboard
                }
                else
                {
                    // Redirect to the login page for normal users
                    return RedirectToAction("Login", "User");
                }
            }
            return View(user);  // If there are validation errors, return to the same Register page
        }
    }
    }
