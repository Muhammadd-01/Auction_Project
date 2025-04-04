using Microsoft.AspNetCore.Mvc;

namespace Auction_Project.controller
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Bidding()
        {
            return View();
        }
        public IActionResult Categories()
        {
            return View();
        }
        public IActionResult Items()
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
        public IActionResult Register()
        {
            return View();
        }
    }
}
