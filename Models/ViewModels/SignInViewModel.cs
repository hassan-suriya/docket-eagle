using System.ComponentModel.DataAnnotations;

namespace Docket_Eagle.Models.ViewModels
{
    public class SignInViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
