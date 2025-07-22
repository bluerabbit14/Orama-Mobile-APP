using Orama.Models;

namespace Orama.Interfaces
{
    public interface ILoginService
    {
        Task<LoginResponse> LoginAsync(string email, string password);
    }
} 