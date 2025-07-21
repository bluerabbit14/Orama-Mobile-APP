using Orama_API.DTO;

namespace Orama_API.Interfaces
{
    public interface IUserService
    {
        Task<SignUpResponseDTO> RegisterUserAsync(SignUpRequestDTO sigUpRequestDto);
        Task<LoginResponseDTO> LoginUserAsync(LoginRequestDTO logInRequestDto);
    }
}
