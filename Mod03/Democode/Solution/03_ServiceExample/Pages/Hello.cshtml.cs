using Microsoft.AspNetCore.Mvc.RazorPages;
using MiddlewareExample.Services;

namespace MiddlewareExample.Pages
{
    public class HelloModel : PageModel
    {
        private readonly ILog _log;
        public HelloModel(ILog log)
        {
            _log = log;
        }

        public void OnGet()
        {
            _log.Write("Showing the Hello page");
        }
    }
}
