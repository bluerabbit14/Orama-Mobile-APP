using Microsoft.EntityFrameworkCore;
using Orama_API.Data;
using Orama_API.Domain;
using Orama_API.DTO;
using Orama_API.Interfaces;

namespace Orama_API.Services
{
    public class UserService : IUserService
    {
        private readonly UserDbContext _context; //here we are using the UserDbContext to interact with the database
        public UserService(UserDbContext context)
        {
            _context = context; //we are injecting the UserDbContext into the UserService
        }
        public async Task<SignUpResponseDTO> RegisterUserAsync(SignUpRequestDTO signUpRequestDto)
        {
            if (string.IsNullOrWhiteSpace(signUpRequestDto.Name))
                throw new ArgumentException("Name is required.");

            if (string.IsNullOrWhiteSpace(signUpRequestDto.Email))
                throw new ArgumentException("Email is required.");

            if (string.IsNullOrWhiteSpace(signUpRequestDto.Password))
                throw new ArgumentException("Password is required.");


            var existingUser = await _context.UserProfilies.FirstOrDefaultAsync(u =>
                (!string.IsNullOrEmpty(signUpRequestDto.Email) && u.Email == signUpRequestDto.Email));

            if (existingUser != null)
            {
                if (!string.IsNullOrEmpty(signUpRequestDto.Email) && existingUser.Email == signUpRequestDto.Email)
                {
                    var conflictMessage = "Email is already registered.";
                    throw new InvalidOperationException(conflictMessage);
                }
            }
            var newUser = new UserProfile
            {
                Name = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(signUpRequestDto.Name.ToLower()),
                Email = signUpRequestDto.Email,
                Password = signUpRequestDto.Password,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            await _context.UserProfilies.AddAsync(newUser);
            await _context.SaveChangesAsync();

            var result = new SignUpResponseDTO
            {
                Message = "User Registered Successfully",
                UserId = newUser.UserId,
                Email = newUser.Email ?? string.Empty,
                CreatedAt = newUser.CreatedAt,
            };
            return result;
        }
        public async Task<LoginResponseDTO> LoginUserAsync(LoginRequestDTO logInRequestDto)
        {
            if (string.IsNullOrWhiteSpace(logInRequestDto.Email))
                throw new ArgumentException("Email is required field.");

            if (string.IsNullOrWhiteSpace(logInRequestDto.Password))
                throw new ArgumentException("Password is required field.");

            var user = await _context.UserProfilies
                .FirstOrDefaultAsync(u => u.Email == logInRequestDto.Email);

            if (user == null)
                throw new InvalidOperationException("User does not exist");

            if (user.IsActive == false)
                throw new InvalidOperationException("User is not active");

            if (user.Password != logInRequestDto.Password) // Corrected line
                throw new InvalidOperationException("Invalid Password");

            user.LastLogin = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            var result = new LoginResponseDTO()
            {
                Message = "User Logged in successfully",
                UserId = user.UserId,
                Logintime = DateTime.UtcNow
            };
            return result;
        }
    }
}
