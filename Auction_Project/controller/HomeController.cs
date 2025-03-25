using Microsoft.AspNetCore.Mvc;

namespace Auction_Project.controller
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
