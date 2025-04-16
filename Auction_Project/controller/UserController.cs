using Auction_Project;
using Microsoft.AspNetCore.Mvc;
using Auction_Project.models;

namespace Auction_Project.controller
{
    public class UserController : Controller
    {
        private readonly AuctionClass _context;

        // Constructor to inject context
        public UserController(AuctionClass context)
        {
            _context = context;
        }

        // Home page (index)
        public IActionResult Index()
        {
            return View();
        }

        // Search results page
        public IActionResult Searchresult()
        {
            return View();
        }

        // All Items page
        public IActionResult Items()
        {
            return View();
        }

        // Bidding page
        public IActionResult Bidding()
        {
            return View();
        }

        // Bidder page
        public IActionResult Bidder()
        {
            return View();
        }

        // Category Pages for Furniture, Electronics, Books, etc.
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

        // Add Seller page (requires login)
        public IActionResult AddSeller()
        {
            var login = HttpContext.Session.GetString("userSession");
            if (login != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // POST: AddSeller (to save seller info)
        [HttpPost]
        public IActionResult AddSeller(Seller _seller)
        {
            var login = HttpContext.Session.GetString("userSession");

            if (login != null)
            {
                _seller.UserId = int.Parse(login);
                _context.tbl_Seller.Add(_seller);
                _context.SaveChanges();
                return RedirectToAction("Profile");
            }

            return RedirectToAction("Login");
        }

        // Profile page (User info page)
        public IActionResult Profile()
        {
            var userIdString = HttpContext.Session.GetString("userSession");

            if (string.IsNullOrEmpty(userIdString))
                return RedirectToAction("Login", "User");

            // Check if the session value is "admin"
            if (userIdString == "admin")
            {
                // If it's "admin", redirect to the admin dashboard
                return RedirectToAction("Dashboard", "Admin");
            }

            // Try parsing the userId as an integer for regular users
            if (!int.TryParse(userIdString, out int userId))
            {
                // If parsing fails, redirect to login page
                return RedirectToAction("Login", "User");
            }

            var user = _context.tbl_Users.FirstOrDefault(u => u.id == userId);

            if (user == null)
                return RedirectToAction("Login", "User");

            return View(user);
        }

        // Logout action to clear session data
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "User");
        }

        // Login GET action
        public IActionResult Login()
        {
            return View();
        }

        // Login POST action
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Admin login
            if (email == "admin@gmail.com" && password == "admin123")
            {
                HttpContext.Session.SetString("userSession", "admin");
                return RedirectToAction("Dashboard", "Admin");
            }

            // Normal user login
            var user = _context.tbl_Users.FirstOrDefault(u => u.email == email && u.password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("userSession", user.id.ToString());
                HttpContext.Session.SetString("userName", user.username);
                return RedirectToAction("Index", "User");
            }

            ViewBag.Message = "Invalid credentials";
            return View();
        }

        // Register GET action
        public IActionResult Register()
        {
            return View();
        }

        // Register POST action
        [HttpPost]
        public IActionResult Register(Users user)
        {
            _context.tbl_Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login", "User");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddBook(Books book)
        {
            var login = HttpContext.Session.GetString("userSession");

            if (string.IsNullOrEmpty(login))
                return RedirectToAction("Login", "User");

            book.SellerID = int.Parse(login);

            _context.tbl_Books.Add(book);
            _context.SaveChanges();

            return RedirectToAction("Index", "User");
        }


    }
}
