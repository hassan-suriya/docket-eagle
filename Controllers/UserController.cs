using Microsoft.AspNetCore.Mvc;

namespace Docket_Eagle.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [Route("delete")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            await _userRepository.DeleteAsync(userId);
            return RedirectToAction("Admin", "Dashboard");
        }
        [Route("paidUser")]
        public async Task<IActionResult> MarkAsPaid(string userId)
        {
            await _userRepository.MarkAsPaid(userId);
            return RedirectToAction("Admin", "Dashboard");
        }
        [Route("activate")]
        public async Task<IActionResult> ActivateUser(string userId)
        {
            await _userRepository.ActivateUser(userId);
            return RedirectToAction("Admin", "Dashboard");
        }
        [Route("deactivate")]
        public async Task<IActionResult> DeactivateUser(string userId)
        {
            await _userRepository.DeactivateUser(userId);
            return RedirectToAction("Admin", "Dashboard");
        }
    }
}
