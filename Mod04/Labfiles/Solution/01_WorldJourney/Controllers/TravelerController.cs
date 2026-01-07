using Microsoft.AspNetCore.Mvc;

namespace WorldJourney.Controllers
{
    public class TravelerController : Controller
    {
        public IActionResult Index(string name)
        {
            ViewBag.VisitorName = name;
            return View();
        }
    }
}
