using Microsoft.AspNetCore.Mvc;

namespace Docket_Eagle.Controllers
{
    public class DashboardController : Controller
    {
        [Route("admin")]
        public IActionResult Admin()
        {
            return View();
        }
        [Route("client")]
        public IActionResult Client()
        {
            return View();
        }
    }
}
