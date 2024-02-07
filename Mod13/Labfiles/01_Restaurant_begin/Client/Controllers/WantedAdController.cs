using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class WantedAdController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}