using Docket_Eagle.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Docket_Eagle.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        
    }
}
