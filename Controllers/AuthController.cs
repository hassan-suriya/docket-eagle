using Docket_Eagle.Models.ViewModels;
using DocketEagle.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Docket_Eagle.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [Route("signin")]
        public IActionResult Signin()
        {
            return View();
        }
        [Route("register")]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost("HandleSignin")]
        public async Task<IActionResult> HandleSignin(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user=await _userRepository.GetByEmail(model.Email);
                if(user!=null && HashPassword.GetHashPassword(model.Password) == user.Password)
                {
                    await HttpContext.SignInAsync("authCookie", new ClaimsPrincipal(
                       new ClaimsIdentity(new List<Claim>
                       {
                             new Claim(ClaimTypes.Role, user.Role)
                       },
                       "authCookie")));
                    if (user.Role == "Admin")
                    {
                        return RedirectToAction("Admin", "Dashboard");
                    }
                   
                    return RedirectToAction("Client", "Dashboard");
                }
            }
            return RedirectToAction("Signin");

        }

        [HttpPost("HandleRegister")]
        public async Task<IActionResult> HandleRegister(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _userRepository.CreateAsync(new Models.User() { Fullname=model.FirstName+" "+model.LastName, Email=model.Email, Password= HashPassword.GetHashPassword(model.Password), Plan=model.Plan, SocialMedia=model.SocialMedia,SocialMediaHandle=model.SocialMediaHandle, BillingCycle=model.BillingCycle, CaseDetails=model.CaseDetails, Role="User"});
                return RedirectToAction("Signin");
            }
            return RedirectToAction("Regiser");

        }
    }
}
