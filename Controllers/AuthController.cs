using Microsoft.AspNetCore.Mvc;

namespace Docket_Eagle.Controllers
{
    public class AuthController : Controller
    {
        [Route("signin")]
        public IActionResult Signin()
        {
            return View();
        }
        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}
