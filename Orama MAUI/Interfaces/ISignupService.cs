using Orama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orama.Interfaces
{
    public interface ISignUpService
    {
        Task<SignupResponse> SignupAsync(string Name,string email, string password);
        Task<bool> EmailRegisteredAsync(string Email);
    }
}
