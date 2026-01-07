using Microsoft.AspNetCore.Mvc;

namespace WorldJourney.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "City");
        }
    }
}
