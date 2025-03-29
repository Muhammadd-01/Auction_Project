using Microsoft.AspNetCore.Mvc;

namespace Auction_Project.controller
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
