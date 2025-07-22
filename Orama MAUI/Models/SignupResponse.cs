using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orama.Models
{
    public class SignupResponse
    {
        public required string Message { get; set; }
        public int? UserId { get; set; }
        public string? Email { get; set; }
        public DateTime? CreatedAt{ get; set; }
    }
}
