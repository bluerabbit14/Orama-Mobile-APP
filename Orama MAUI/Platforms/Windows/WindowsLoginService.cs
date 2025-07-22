using Orama.Models;
using Orama.Services;
using Orama.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;

namespace Orama.Platforms.Windows
{
    public class WindowsLoginService : ILoginService
    {
        private readonly WindowAuthorizeService _authorizeServices;

        public WindowsLoginService()
        {
            _authorizeServices = new WindowAuthorizeService();
        }

        public async Task<LoginResponse> LoginAsync(string email, string password)
        {
            try
            {
                var request = new LoginRequest { Email = email, Password = password };
                var response = await _authorizeServices.UserLoginAsync(request);
                return response;
            }
            catch (Exception ex)
            {
                return new LoginResponse { Message = $"Login failed: {ex.Message}" };
            }
        }
    }
} 