using Microsoft.AspNetCore.Mvc;

namespace CrossSiteRequestForgeryAttack.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
