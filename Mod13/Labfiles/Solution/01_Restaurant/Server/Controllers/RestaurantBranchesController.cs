using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Data;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantBranchesController : ControllerBase
    {
        private RestaurantContext _context;

        public RestaurantBranchesController(RestaurantContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<RestaurantBranch>> Get()
        {
            var branches = from r in _context.RestaurantBranches
                           orderby r.City
                           select r;
            return branches.ToList();
        }
    }
}
