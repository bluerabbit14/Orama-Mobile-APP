using System.ComponentModel.DataAnnotations;

namespace Orama_API.DTO
{
    public class SignUpResponseDTO
    {
        [Required] public string Message { get; set; }
        [Required] public int UserId { get; set; }
        [EmailAddress] public required string Email { get; set; }
        [Required] public DateTime CreatedAt { get; set; }
    }
}
