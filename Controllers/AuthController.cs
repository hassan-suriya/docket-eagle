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
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            var claims = User.Claims.ToList();
            if (claims[0].Value == "Admin")
            {
                return RedirectToAction("Admin","Dashboard");
            }
            return RedirectToAction("Client", "Dashboard");
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
                    if (user.PaymentStatus == false)
                    {
                        ModelState.AddModelError(string.Empty, "Signin Failed. Payment status not verified");
                    }
                    else if(user.Status == false)
                    {
                        ModelState.AddModelError(string.Empty, "Signin Failed. Account has been deactivated");
                    }
                    else
                    {
                        return RedirectToAction("Client", "Dashboard");
                    }
                   
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Signin Failed. Invalid Credentials");
                   
                }
            }
            return View("Signin",model);

        }

        [HttpPost("HandleRegister")]
        public async Task<IActionResult> HandleRegister(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _userRepository.CreateAsync(new Models.User() { Fullname=model.FirstName+" "+model.LastName, Email=model.Email, Password= HashPassword.GetHashPassword(model.Password), Plan=model.Plan, SocialMedia=model.SocialMedia,SocialMediaHandle=model.SocialMediaHandle, BillingCycle=model.BillingCycle, CaseDetails=model.CaseDetails, Role="User"});
                TempData["SuccessMessage"] = "Registration successful You can now sign in.";
                return RedirectToAction("Signin");
            }
            ModelState.AddModelError(string.Empty, "Registration Failed. Invalid data entered");
            return View("Register",model);

        }

        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("authCookie");
            return RedirectToAction("Signin", "Auth");

        }
    }
}
