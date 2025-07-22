using Microsoft.EntityFrameworkCore;
using Orama_API.Data;
using Orama_API.Domain;
using Orama_API.DTO;
using Orama_API.Interfaces;

namespace Orama_API.Services
{
    public class AdminService : IAdminService
    {
        private readonly UserDbContext _context;
        public AdminService(UserDbContext context)
        {
            _context = context; //we are injecting the UserDbContext into the UserService
        }
        
        public async Task<IEnumerable<UserProfile>> GetAllUserAsync()
        {
            return await _context.UserProfilies
                .OrderBy(u => u.CreatedAt)
                .ToListAsync();
        }
        
        public async Task<UserProfile?> GetUserByIdAsync(int id)
        {
            var user = await _context.UserProfilies
                .FirstOrDefaultAsync(u => u.UserId == id);
                
            if (user == null)
                throw new InvalidOperationException($"User with ID {id} not found.");
                
            return user;
        }
        
        public async Task<UserProfile?> GetUserByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be null or empty.");
                
            var user = await _context.UserProfilies
                .FirstOrDefaultAsync(u => u.Email == email);
                
            if (user == null)
                throw new InvalidOperationException($"User with email '{email}' not found.");
                
            return user;
        }
        
        public async Task<UserProfile?> GetUserByPhoneAsync(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentException("Phone number cannot be null or empty.");
                
            var user = await _context.UserProfilies
                .FirstOrDefaultAsync(u => u.Phone == phone);
                
            if (user == null)
                throw new InvalidOperationException($"User with phone number '{phone}' not found.");
                
            return user;
        }
        
        public async Task<UserStatusResponseDTO?> AlterUserStatusAsync(int id)
        {
            var user = await _context.UserProfilies
                .FirstOrDefaultAsync(u => u.UserId == id);
                
            if (user == null)
                throw new InvalidOperationException($"User with ID {id} not found.");
                
            // Toggle the IsActive status
            user.IsActive = !user.IsActive;
            user.LastUpdated = DateTime.UtcNow;
            
            await _context.SaveChangesAsync();
            
            return new UserStatusResponseDTO
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                IsActive = user.IsActive,
                LastUpdated = user.LastUpdated,
                Message = $"User status updated successfully. User is now {(user.IsActive ? "Active" : "Inactive")}."
            };
        }
    }
}
