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

        // GET: Login
        [HttpGet]
        public IActionResult Login()
        {
            return View(new Users()); // Pass an empty Users model to the view
        }


        // POST: Login
        [HttpPost]
        public IActionResult Login(Users model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.tbl_Users
                    .FirstOrDefault(u => u.email == model.email && u.password == model.password); // Use lowercase `email` and `password`

                if (user != null)
                {
                    // Check if the user is the admin
                    if (user.email == "admin@gmail.com" && user.password == "admin123")
                    {
                        return RedirectToAction("Dashboard", "Admin"); // Redirect to Admin panel
                    }

                    // Regular user
                    return RedirectToAction("Index", "User"); // Redirect to User's homepage
                }

                // If user is not found, show error message
                ViewBag.LoginError = "Invalid email or password.";
            }

            // If the model is not valid or login failed, return the same view with the model data to preserve input
            return View(model);
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
