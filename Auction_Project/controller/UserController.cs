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
        [HttpGet]
        public IActionResult Login()
        {
            return View(); // return the login view
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Find user in the database
            var user = _context.tbl_Users.FirstOrDefault(u => u.email == email && u.password == password);

            if (user != null)
            {
                // Check if the user is the admin
                if (user.email == "admin@gmail.com" && user.password == "admin123") // You can modify this logic
                {
                    // Redirect to Admin Dashboard
                    return RedirectToAction("Dashboard", "Admin");
                }

                // Regular user (You can modify this as well if you want more specific checks)
                return RedirectToAction("Index", "User"); // or User's homepage or profile
            }

            // If no matching user found, show error message
            ViewBag.LoginError = "Invalid email or password.";
            return View(); // Return the same login view with the error
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


            }
            return View(user);  // If there are validation errors, return to the same Register page
        }
    }
    }
