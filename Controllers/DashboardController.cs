﻿using Docket_Eagle.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Docket_Eagle.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IUserRepository _userRepository;

        public DashboardController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [Route("admin")]
        public async Task<IActionResult> Admin()
        {
            if (User.Identity.IsAuthenticated)
            {
                var claims = User.Claims.ToList();
                if(claims[0].Value == "Admin")
                {
                    var users = await _userRepository.GetAllAsync();
                    return View(new AdminViewModel() { Users=users});
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
