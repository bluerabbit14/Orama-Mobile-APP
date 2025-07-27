using Orama.Interfaces;
using Orama.Models;
using System.Net.Http.Json;
using System.Reflection.Metadata;

namespace Orama.Platforms.Windows
{
    public class WindowAuthorizeService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private const string BaseApiUrl = "http://localhost:5112/api/"; // Define the BaseApiUrl constant

        public WindowAuthorizeService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<object> SignupAsync(string name, string email, string password)
        {
            SignupRequest signUpRequest = new SignupRequest
            {
                Name = name,
                Email = email,
                Password = password
            };
            try
            {
                var response = await _httpClient.PostAsJsonAsync(BaseApiUrl + "User/Register", signUpRequest);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<object>();
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request errors
                throw new Exception($"SignUp request failed: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                // Handle other errors
                throw new Exception($"Unexpected error during login: {ex.Message}", ex);
            }
        }

        public async Task<object> LoginAsync(string email, string password)
        {
            LoginRequest logInRequest = new LoginRequest
            {
                Email = email,
                Password = password
            };
            try
            {
                var response = await _httpClient.PostAsJsonAsync(BaseApiUrl + "User/Authorize", logInRequest);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<object>();
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request errors
                throw new Exception($"Login request failed: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                // Handle other errors
                throw new Exception($"Unexpected error during login: {ex.Message}", ex);
            }
        }

        public async Task<bool> EmailRegisteredAsync(string email)
        {
            try
            {
                var response = await _httpClient.GetAsync(BaseApiUrl + $"Email_Service/IsEmailRegistered?Email={email}");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                return bool.TryParse(result, out var isRegistered) && isRegistered;
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request errors
                throw new Exception($"Email check request failed: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                // Handle other errors
                throw new Exception($"Unexpected error during email check: {ex.Message}", ex);
            }
        }

        public async Task<object> ChangePasswordAsync(string email, string newPassword)
        {
            ChangePasswordRequest request = new ChangePasswordRequest
            {
                Email = email,
                NewPassword = newPassword
            };
            try
            {
                var response = await _httpClient.PostAsJsonAsync(BaseApiUrl + "User/ChangePassword", request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<object>();
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request errors
                throw new Exception($"Login request failed: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                // Handle other errors
                throw new Exception($"Unexpected error during login: {ex.Message}", ex);
            }
        }
    }
}
