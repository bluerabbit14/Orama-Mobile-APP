using Orama_API.DTO;

namespace Orama_API.Interfaces
{
    public interface IUserService
    {
        Task<SignUpResponseDTO> RegisterUserAsync(SignUpRequestDTO sigUpRequestDto);
        Task<LoginResponseDTO> LoginUserAsync(LoginRequestDTO logInRequestDto);
        Task<ChangePasswordResponseDTO> PasswordUserAsync(ChangePasswordRequestDTO changePasswordRequestDto);
        Task<bool> EmailRegisteredAsync(string Email);
        Task<bool> VerifyUserEmailAsync(string Email);
        Task<bool> VerifyUserPhoneAsync(string Phone);
        
    }
}
