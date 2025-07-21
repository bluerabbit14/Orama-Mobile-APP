using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Orama_API.DTO
{
    public class LoginResponseDTO
    {
        public required string Message { get; set; }
        public int? UserId { get; set; }     
        public DateTime? Logintime { get; set; }
    }
}
