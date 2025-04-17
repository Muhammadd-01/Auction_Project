using Microsoft.AspNetCore.Mvc;
using Auction_Project.models;
using System.Linq;
using Auction_Project;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult AddCategories()
        {
            return View();
        }

        public IActionResult ManageItems()
        {
            return View();
        }
        public IActionResult Category()
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
            var booksList = _context.tbl_Books.ToList();

            // Log to confirm if data is fetched properly
            Console.WriteLine($"Fetched {booksList.Count} books.");

            return View(booksList);
        }
        // Method to delete a book by its ItemID
        public IActionResult DeleteBook(int id)
        {
            // Find the book by its ItemID
            var bookToDelete = _context.tbl_Books.FirstOrDefault(b => b.ItemID == id);

            if (bookToDelete != null)
            {
                // If the book exists, remove it from the database
                _context.tbl_Books.Remove(bookToDelete);
                _context.SaveChanges(); // Commit the changes to the database

                // Optionally, display a success message (TempData can be used for this purpose)
                TempData["msg"] = "Book deleted successfully!";
            }
            else
            {
                // If the book does not exist, you might want to show an error message
                TempData["msg"] = "Book not found!";
            }

            // Redirect back to the Books list (or AllBooks)
            return RedirectToAction("Books"); // or RedirectToAction("AllBooks");
        }

        public IActionResult Furniture()
        {
            // Fetch the list of furniture from the database
            var furnitureList = _context.tbl_Furnitures.ToList();

            // Log to confirm if data is fetched properly
            Console.WriteLine($"Fetched {furnitureList.Count} furniture items.");

            // Return the list of furniture to the view
            return View(furnitureList);
        }


        public IActionResult Electronics()
        {
            // Fetch the list of electronics from the database
            var electronicsList = _context.tbl_Electronics.ToList();

            // Log to confirm if data is fetched properly
            Console.WriteLine($"Fetched {electronicsList.Count} electronics.");

            // Return the list of electronics to the view
            return View(electronicsList);
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

        public IActionResult UserToSeller()
        {
            var seller = _context.tbl_Seller.Include(p => p.Users).ToList();

            return View(seller);
        }





    }
}