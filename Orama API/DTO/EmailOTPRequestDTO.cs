using System.ComponentModel.DataAnnotations;

namespace Orama_API.DTO
{
    public class EmailOTPRequestDTO
    {
       [Required][EmailAddress] public string Email { get; set; } = string.Empty;
    }
}