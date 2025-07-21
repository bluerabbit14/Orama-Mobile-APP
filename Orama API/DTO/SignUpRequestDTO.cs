using System.ComponentModel.DataAnnotations;

namespace Orama_API.DTO
{
    public class SignUpRequestDTO
    {
        public required string Name { get; set; }
        [EmailAddress] public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
