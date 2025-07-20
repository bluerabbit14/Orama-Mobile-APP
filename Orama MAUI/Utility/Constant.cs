using Orama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orama.Utility
{
    class Constant
    {
       
        public static readonly LoginResponse Response1 = new LoginResponse()
        {
            UserId = 2,
            ImageUrl = null,
            Name = "Asif Abbas",
            Email = "14asifcr7@gmail.com",
            Phone = "8445941678",
            Address = "Saga Emporium,Agra",
            Pincode = null,
            DateOfBirth = "2004-03-24",
            Gender = "Male",
            Role = "user",
            CreatedAt = DateTime.Parse("2025-06-20T11:33:56.9821666"),
            LastUpdated = DateTime.Parse("2025-06-20T17:03:57.09"),
            
            IsEmailVerified = false,
            IsPhoneVerified = false,
            
            RememberMe = false,
            Bio = null,
            
            Lastlogin = DateTime.Parse("2025-06-28T12:05:53.648Z")
        };
    }
}
