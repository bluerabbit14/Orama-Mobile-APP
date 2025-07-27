using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orama.Models
{
    public class ChangePasswordRequest
    {
        
        public required string Email { get; set; }
        public required string NewPassword { get; set; }
    }
}
