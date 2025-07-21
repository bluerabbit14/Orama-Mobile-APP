using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orama.Models
{
    public class LoginRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public DateTime LastLogin { get; set; }

    }
}
