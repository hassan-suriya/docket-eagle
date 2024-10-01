using Microsoft.AspNetCore.Mvc;

namespace Docket_Eagle.Controllers
{
    public class DashboardController : Controller
    {
        [Route("admin")]
        public IActionResult Admin()
        {
            if (User.Identity.IsAuthenticated)
            {
                var claims = User.Claims.ToList();
                if(claims[0].Value == "Admin")
                {
                    return View();
                }
            }
            return RedirectToAction("Signin", "Auth");
        }
        [Route("client")]
        public IActionResult Client()
        {
            if (User.Identity.IsAuthenticated)
            {
                var claims = User.Claims.ToList();
                if (claims[0].Value == "User")
                {
                    return View();
                }
            }
            return RedirectToAction("Signin", "Auth");
        }
    }
}
