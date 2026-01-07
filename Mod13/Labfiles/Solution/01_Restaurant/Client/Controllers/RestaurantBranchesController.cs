using Microsoft.AspNetCore.Mvc;
using Client.Models;

namespace Client.Controllers
{
    public class RestaurantBranchesController : Controller
    {
        private IHttpClientFactory _httpClientFactory;

        public RestaurantBranchesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("http://localhost:54517");
            HttpResponseMessage response = await httpClient.GetAsync("api/RestaurantBranches");
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<RestaurantBranch> restaurantBranches = await response.Content.ReadAsAsync<IEnumerable<RestaurantBranch>>();
                return View(restaurantBranches);
            }
            else
            {
                return View("Error");
            }
        }
    }
}
