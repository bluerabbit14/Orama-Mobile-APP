using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orama.Models
{
    public class LoginResponse
    {
        public int UserId { get; set; }
        public string? ImageUrl { get; set; } 
        public string? Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Pincode { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Gender { get; set; } 
        public required string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsPhoneVerified { get; set; }
        public bool RememberMe { get; set; }
        public string? Bio { get; set; } 
        public DateTime Lastlogin { get; set; }
    }
}
