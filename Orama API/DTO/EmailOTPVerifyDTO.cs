using System.ComponentModel.DataAnnotations;

namespace Orama_API.DTO
{
    public class EmailOTPVerifyDTO
    {
        [Required][EmailAddress] public string Email { get; set; } = string.Empty;
        [Required] [StringLength(6, MinimumLength = 6)] public string OTP { get; set; } = string.Empty;
    }
}