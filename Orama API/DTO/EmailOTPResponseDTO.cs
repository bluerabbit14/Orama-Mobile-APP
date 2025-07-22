namespace Orama_API.DTO
{
    public class EmailOTPResponseDTO
    {
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}