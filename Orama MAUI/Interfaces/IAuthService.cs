using Orama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orama.Interfaces
{
    public interface IAuthService
    {
        Task<object> SignupAsync(string Name, string email, string password);
        Task<object> LoginAsync(string email, string password);
        Task<bool> EmailRegisteredAsync(string Email);
        Task<object> ChangePasswordAsync(string email, string newPassword);
    }
}
