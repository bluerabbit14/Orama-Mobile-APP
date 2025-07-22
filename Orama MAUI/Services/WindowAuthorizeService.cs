using Orama.Models;
using Orama.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Orama.Services
{
    internal class WindowAuthorizeService
    {
        private readonly HttpClient _httpClient;

        public WindowAuthorizeService() 
        {
            _httpClient = new HttpClient();
        }

        public async Task<LoginResponse> UserLoginAsync(LoginRequest logInRequest)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(Constant.WindowLoginApiUrl + "/Login", logInRequest);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<LoginResponse>();
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
        public async Task<SignupResponse> UserSignupAsync(SignupRequest signUpRequest)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(Constant.WindowLoginApiUrl + "/Register", signUpRequest);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<SignupResponse>();
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
    }
}

