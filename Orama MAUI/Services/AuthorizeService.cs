using Orama.Interfaces;
using Orama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orama.Services
{
    class AuthorizeService:IAuthService
    {
        public Task<object> SignupAsync(string Name, string email, string password)
        {
            return null;
        }
        public Task<object> LoginAsync(string email, string password)
        {
            return null;
        }
        public Task<bool> EmailRegisteredAsync(string Email)
        {
            return Task.FromResult(false);
        }
        public Task<object> ChangePasswordAsync(string email, string newPassword)
        {
            return null;
        }
    }
}
