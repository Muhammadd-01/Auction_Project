using Auction_Project;
using Microsoft.AspNetCore.Mvc;
using Auction_Project.models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
//using Microsoft_ebHostEnvironment;

namespace Auction_Project.controller
{
    public class UserController : Controller
    {
        private readonly AuctionClass _context;


        private readonly IWebHostEnvironment _webHostEnvironment;


        public UserController(AuctionClass context, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
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
        public IActionResult About()
        {
            return View();
        }

        // All Items page
        // Action to display the book item details
        public IActionResult BookItems(int id)
        {
            var book = _context.tbl_Books
                        .Include(b => b.Seller) // 👈 This will load the related Seller
                        .FirstOrDefault(b => b.ItemID == id);

            if (book == null)
            {
                return NotFound(); // Item not found
            }

            return View(book);
        }
        // Action to display the electronic item details
        public IActionResult ElectronicItems(int id)
        {
            var electronic = _context.tbl_Electronics
                                .Include(e => e.Seller) // Load related Seller
                                .FirstOrDefault(e => e.ItemID == id);

            if (electronic == null)
            {
                return NotFound(); // Item not found
            }

            return View(electronic);
        }
        // Action to display the furniture item details
        public IActionResult FurnitureItems(int id)
        {
            var furniture = _context.tbl_Furnitures
                                .Include(f => f.Seller) // Load related Seller
                                .FirstOrDefault(f => f.ItemID == id);

            if (furniture == null)
            {
                return NotFound(); // Item not found
            }

            return View(furniture);
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
            var furnitures = _context.tbl_Furnitures.ToList(); // get all books from DB
            return View(furnitures); // send to view
        }

        public IActionResult Electronics()
        {
            var electronics = _context.tbl_Electronics.ToList(); // get all books from DB
            return View(electronics); // send to view
        }

        public IActionResult Books()
        {
            var books = _context.tbl_Books.ToList(); // get all books from DB
            return View(books); // send to view
        }

        // Add Seller page (requires login)

        [HttpGet]
        public IActionResult AddSeller()
        {
            var login = HttpContext.Session.GetString("userSession");

            if (login != null)
            {
                int userId = int.Parse(login);
                var user = _context.tbl_Users.FirstOrDefault(u => u.id == userId);

                if (user != null)
                {
                    ViewBag.Username = user.username;
                    ViewBag.Email = user.email;
                    return View(); // This loads your seller form
                }
            }

            return RedirectToAction("Login");
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
        [HttpGet]
        public IActionResult Add_Book()
        {
            var login = HttpContext.Session.GetString("userSession");
            ViewBag.IsSeller = false; // Default to false

            if (login != null)
            {
                var seller = _context.tbl_Seller.FirstOrDefault(p => p.SellerId == int.Parse(login));
                if (seller != null)
                {
                    ViewBag.IsSeller = true; // Set to true if seller is found
                }
            }

            return View(); // Proceed with the view
        }


        [HttpPost]
        public IActionResult Add_Book(Books book, IFormFile ItemImage)
        {
            var login = HttpContext.Session.GetString("userSession");

            if (login != null)
            {
                var seller = _context.tbl_Seller.FirstOrDefault(p => p.SellerId == int.Parse(login));
                if (seller == null)
                {
                    TempData["msg"] = "You need to become a seller before adding books.";
                    return RedirectToAction("AddSeller", "User");
                }

                string extension = Path.GetExtension(ItemImage.FileName).ToLower();
                if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                {
                    string randomNum = new Random().Next(1000, 9999).ToString();
                    string fileName = "book_" + randomNum + extension;

                    string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "books_covers");
                    string filePath = Path.Combine(folderPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        ItemImage.CopyTo(stream);
                    }

                    book.SellerID = seller.SellerId;
                    book.book_cover = fileName;
                    _context.tbl_Books.Add(book);
                    _context.SaveChanges();

                    TempData["msg"] = "Book added successfully!";
                    return RedirectToAction("Books", "User");
                }
                else
                {
                    TempData["msg"] = "Only JPG, PNG, and JPEG files are allowed.";
                    return RedirectToAction("Books", "User");
                }
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }



        public IActionResult Add_Electronic()
        {
            var login = HttpContext.Session.GetString("userSession");
            if (login != null)
            {
                var sellers = _context.tbl_Seller.FirstOrDefault(p => p.SellerId == int.Parse(login));
                if (sellers != null)
                {
                    return View();
                }
                else
                {
                    TempData["msg"] = "please add yourself as seller first";
                    return RedirectToAction("AddSeller", "User");
                }
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        [HttpPost]
        public IActionResult Add_Electronic(Electronics electronic, IFormFile ItemImage)
        {
            var login = HttpContext.Session.GetString("userSession");

            if (login != null)
            {
                string extension = Path.GetExtension(ItemImage.FileName).ToLower();
                if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                {
                    Random rnd = new Random();
                    string randomNum = rnd.Next(1000, 9999).ToString();
                    string fileName = "electronic_" + randomNum + extension;

                    string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "electronics_covers");
                    string filePath = Path.Combine(folderPath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        ItemImage.CopyTo(stream);
                    }

                    var seller = _context.tbl_Seller.FirstOrDefault(p => p.SellerId == int.Parse(login));
                    electronic.SellerID = seller.SellerId;
                    electronic.Electronic_cover = fileName; // Save only file name
                    _context.tbl_Electronics.Add(electronic);
                    _context.SaveChanges();

                    TempData["msg"] = "Electronic item added successfully!";
                    return RedirectToAction("Electronics", "User");
                }
                else
                {
                    TempData["msg"] = "Only JPG, PNG, and JPEG files are allowed.";
                    return RedirectToAction("Electronics", "User");
                }
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        public IActionResult Add_Furniture()
        {
            var login = HttpContext.Session.GetString("userSession");
            if (login != null)
            {
                var sellers = _context.tbl_Seller.FirstOrDefault(p => p.SellerId == int.Parse(login));
                if (sellers != null)
                {
                    return View();
                }
                else
                {
                    TempData["msg"] = "please add yourself as seller first";
                    return RedirectToAction("AddSeller", "User");
                }
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        [HttpPost]
        public IActionResult Add_Furniture(Furnitures furniture, IFormFile ItemImage)
        {
            var login = HttpContext.Session.GetString("userSession");

            if (login != null)
            {
                string extension = Path.GetExtension(ItemImage.FileName).ToLower();
                if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                {
                    Random rnd = new Random();
                    string randomNum = rnd.Next(1000, 9999).ToString();
                    string fileName = "furniture_" + randomNum + extension;

                    string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "furnitures_covers");
                    string filePath = Path.Combine(folderPath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        ItemImage.CopyTo(stream);
                    }

                    var seller = _context.tbl_Seller.FirstOrDefault(p => p.SellerId == int.Parse(login));
                    furniture.SellerID = seller.SellerId;
                    furniture.Furniture_cover = fileName;
                    _context.tbl_Furnitures.Add(furniture);
                    _context.SaveChanges();

                    TempData["msg"] = "Furniture item added successfully!";
                    return RedirectToAction("Furnitures", "User");
                }
                else
                {
                    TempData["msg"] = "Only JPG, PNG, and JPEG files are allowed.";
                    return RedirectToAction("Furnitures", "User");
                }
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
        // Simple method to add data to tbl_Auctions

        [HttpPost]
        public IActionResult PlaceBid(string Title, string Description, decimal StartingPrice, decimal CurrentHighestBid, DateTime StartTime, DateTime EndTime, int BookId, string UserId)
        {
            try
            {
                // Validate the bid: ensure CurrentHighestBid is greater than the StartingPrice
                if (CurrentHighestBid < StartingPrice || CurrentHighestBid <= 0)
                {
                    ModelState.AddModelError("", "Bid amount must be greater than the starting price.");
                    return View(); // Return the same view with an error message
                }

                // Create a new Auction object
                var auction = new Auction
                {
                    Title = Title,
                    Description = Description,
                    StartingPrice = StartingPrice,
                    CurrentHighestBid = CurrentHighestBid,
                    StartTime = StartTime,
                    EndTime = EndTime,
                    BookId = BookId,
                    UserId = int.Parse(UserId),
                    IsActive = true // Assuming new auction is active by default
                };

                // Add the auction to the context (this adds a new bid entry to the database)
                _context.tbl_Auctions.Add(auction);

                // Save changes to the database
                _context.SaveChanges();

                // Redirect to the auction details page or another confirmation page
                return RedirectToAction("AuctionDetails", new { id = auction.Id });
            }
            catch (Exception ex)
            {
                // Log the error (optional)
                Console.WriteLine(ex.Message); // You may want to use a logger here
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}