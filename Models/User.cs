using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using DocketEagle.Models;
using System.ComponentModel.DataAnnotations;

namespace Docket_Eagle.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SocialMedia { get; set; }

        public string SocialMediaHandle { get; set; }

        public string BillingCycle { get; set; }

        public string Plan { get; set; }

        public List<CaseDetailsViewModel> CaseDetails { get; set; } = new List<CaseDetailsViewModel>() { new CaseDetailsViewModel(), new CaseDetailsViewModel() };

        public string Role { get; set; }
    }
    public class CaseDetails
    {
        public string CaseNumber { get; set; }

        public string CourtDetails { get; set; }
    }
}
