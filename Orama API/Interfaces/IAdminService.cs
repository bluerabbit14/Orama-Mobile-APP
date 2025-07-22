using Orama_API.Domain;
using Orama_API.DTO;

namespace Orama_API.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<UserProfile>> GetAllUserAsync();
        Task<UserProfile?> GetUserByIdAsync(int id);
        Task<UserProfile?> GetUserByEmailAsync(string email);
        Task<UserProfile?> GetUserByPhoneAsync(string phone);
        Task<UserStatusResponseDTO?> AlterUserStatusAsync(int id);

    }
}
