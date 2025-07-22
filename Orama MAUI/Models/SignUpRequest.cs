using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orama.Models
{
    public class SignupRequest
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
