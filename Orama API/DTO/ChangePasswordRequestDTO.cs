namespace Orama_API.DTO
{
    public class ChangePasswordRequestDTO
    {
        public required string Email { get; set; }
        public required string NewPassword { get; set; }

    }
}
