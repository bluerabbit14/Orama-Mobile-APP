using Orama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orama.Interfaces
{
    public interface IChangePasswordService
    {
      Task<ChangePasswordResponse> PasswordAsync(string email,string password);
    }
}
