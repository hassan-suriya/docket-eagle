

using System.ComponentModel.DataAnnotations;

namespace DocketEagle.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }


        [Required]
        public string SocialMedia { get; set; }

        [Required]
        [StringLength(50)]
        public string SocialMediaHandle { get; set; }

        [Required]
        public string BillingCycle { get; set; }

        [Required]
        public string Plan { get; set; }

        [Required]
        public List<CaseDetailsViewModel> CaseDetails { get; set; } = new List<CaseDetailsViewModel>() { new CaseDetailsViewModel(),new CaseDetailsViewModel()};

        [Required]
        public bool AgreeToTerms { get; set; }
    }

    public class CaseDetailsViewModel
    {
        [Required]
        [StringLength(50)]
        public string CaseNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string CourtDetails { get; set; }
    }
}
