using Microsoft.AspNetCore.Mvc;

namespace ElectricStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}