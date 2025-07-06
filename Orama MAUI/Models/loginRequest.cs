using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orama.Models
{
    internal class loginRequest
    {
        public string Credential { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public DateTime LastLogin { get; set; }

    }
}
