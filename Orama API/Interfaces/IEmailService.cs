
using Orama_API.DTO;

namespace Orama_API.Interfaces
{
    public interface IEmailService
    {
        Task<EmailOTPResponseDTO> SendOTPAsync(string email);
        Task<bool> VerifyOTPAsync(string email, string otp);
        Task<bool> ResendOTPAsync(string email);
    }
}