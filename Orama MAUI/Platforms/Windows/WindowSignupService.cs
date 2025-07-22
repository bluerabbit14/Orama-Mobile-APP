using Orama.Interfaces;
using Orama.Models;
using Orama.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orama.Platforms.Windows
{
    public class WindowSignUpService: ISignUpService
    {
        private readonly WindowAuthorizeService _authorizeServices;

        public WindowSignUpService()
        {
            _authorizeServices = new WindowAuthorizeService();
        }

        public async Task<SignupResponse> SignupAsync(string name,string email, string password)
        {
            try
            {
                var request = new SignupRequest {Name=name, Email = email, Password = password };
                var response = await _authorizeServices.UserSignupAsync(request);
                return response;
            }
            catch (Exception ex)
            {
                return new SignupResponse { Message = $"SignUp failed: {ex.Message}" };
            }
        }
    }
}
