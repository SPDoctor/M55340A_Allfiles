using CitiesWebsite.Services;
using Microsoft.AspNetCore.Mvc;

namespace CitiesWebsite.Controllers
{
    public class CityController : Controller
    {
        private ICityProvider _cities;

        public CityController(ICityProvider cities)
        {
            _cities = cities;
        }

        public IActionResult ShowCities()
        {
            ViewBag.Cities = _cities;
            return View();
        }

        public IActionResult ShowDataForCity(string cityName)
        {
            ViewBag.City = _cities[cityName];
            return View();
        }

        public IActionResult GetImage(string cityName)
        {
            return File($@"images\{cityName}.jpg", "image/jpeg");
        }
    }
}