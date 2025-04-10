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


        // POST: Login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.tbl_Users.FirstOrDefault(u => u.email == "admin@gmail.com" && u.password == "admin123");

            if (user != null)
            {

                HttpContext.Session.SetString("userSession",user.id.ToString());
                // User is authenticated, perform necessary actions
                return RedirectToAction("Dashboard", "Admin"); // Redirect to the Admin controller's Dashboard action
            }
            //else if(user != null && user.password != password)
            //{
            //    return RedirectToAction("Login", "User");
            //}
            else
            {
                ViewBag.Message = "Invalid Credentials";
                return View();

            }
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
                // Add the user to the database
                _context.tbl_Users.Add(user);
                _context.SaveChanges();

                // After successfully registering, redirect to the Login page
                return RedirectToAction("Login", "User");
            }

            // If there are validation errors, return to the same Register page with the model data
            return View(user);
        }

    }
}
