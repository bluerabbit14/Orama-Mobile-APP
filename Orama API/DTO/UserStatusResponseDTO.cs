namespace Orama_API.DTO
{
    public class UserStatusResponseDTO
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Message { get; set; } = string.Empty;
    }
} 