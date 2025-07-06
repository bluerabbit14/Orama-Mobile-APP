using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orama.Models
{
    class loginResponse
    {
        public int UserId { get; set; }
        public string ImageUrl { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; } 
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdated { get; set; }
        public string LanguagePreference { get; set; } 
        public string TimeZone { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsPhoneVerified { get; set; }
        public bool IsActive { get; set; }
        public bool RememberMe { get; set; }
        public string Bio { get; set; } 
        public string SocialHandle { get; set; }
        public DateTime Lastlogin { get; set; }
    }
}
