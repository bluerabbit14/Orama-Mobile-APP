﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orama.Models
{
    public class LoginResponse
    {
        public required string Message { get; set; }
        public int? UserId { get; set; }
        public DateTime? Logintime { get; set; }
    }
}
