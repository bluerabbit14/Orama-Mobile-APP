using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orama_API.Domain
{
    public class UserProfile
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int UserId { get; set; }  //primary key, foreign key to UsersPassword table
        public string? ImageUrl { get; set; }
        public string? Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public required string Password { get; set; }
        public string? Address { get; set; }
        public string? Pincode { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdated { get; set; }
        public string? LanguagePreference { get; set; }
        public string? Timezone { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsPhoneVerified { get; set; }
        public bool IsActive { get; set; }
        public string? PremiunmStatus { get; set; } //optional, can be null
        public string? Bio { get; set; }
        public string? SocialHandle { get; set; }
        public DateTime LastLogin { get; set; }

    }
}
