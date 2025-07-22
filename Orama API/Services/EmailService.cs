using Microsoft.EntityFrameworkCore;
using Orama_API.Data;
using Orama_API.DTO;
using Orama_API.Interfaces;
using System.Net;
using System.Net.Mail;

namespace Orama_API.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly UserDbContext _context;
        private readonly Dictionary<string, (string otp, DateTime expiry)> _otpStore = new();

        public EmailService(IConfiguration configuration, UserDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<EmailOTPResponseDTO> SendOTPAsync(string email)
        {
            try
            {
                // Check if user exists
                var user = await _context.UserProfilies
                    .FirstOrDefaultAsync(u => u.Email == email);

                if (user == null)
                    return new EmailOTPResponseDTO
                    {
                        Message = $"User with Email: {email} not found.",
                        Success = false,
                        Email = email
                    };

                if (user.IsEmailVerified)
                    return new EmailOTPResponseDTO
                    {
                        Message = "Email is already verified",
                        Success = true,
                        Email = email
                    };

                // Generate 6-digit OTP
                var otp = GenerateOTP();
                var expiry = DateTime.UtcNow.AddMinutes(5); // OTP expires in 5 minutes

                // Store OTP in memory (in production, use Redis or database)
                _otpStore[email] = (otp, expiry);

                // Send email
                await SendEmailAsync(email, "Email Verification OTP", 
                    $"Your verification OTP is: {otp}\n\nThis OTP will expire in 5 minutes.");

                return new EmailOTPResponseDTO
                {
                    Message = "OTP sent successfully",
                    Success = true,
                    Email = email
                };
            }
            catch (Exception ex)
            {
                return new EmailOTPResponseDTO
                {
                    Message = $"Failed to send OTP: {ex.Message}",
                    Success = false,
                    Email = email
                };
            }
        }
        public async Task<bool> VerifyOTPAsync(string email, string otp)  //showing error in this line otp not verified
        {
            if (!_otpStore.ContainsKey(email))
                return false;

            var (storedOtp, expiry) = _otpStore[email];

            if (DateTime.UtcNow > expiry)
            {
                _otpStore.Remove(email);
                return false;
            }

           // Case-insensitive comparison
            if (string.Equals(storedOtp, otp, StringComparison.OrdinalIgnoreCase))
            {
                _otpStore.Remove(email);
                
                // Update user verification status
                var user = await _context.UserProfilies
                    .FirstOrDefaultAsync(u => u.Email == email);
                
                if (user != null)
                {
                    user.IsEmailVerified = true;
                    user.LastUpdated = DateTime.UtcNow;
                    await _context.SaveChangesAsync();
                }
                
                return true;
            }

            return false;
        }
         public async Task<bool> ResendOTPAsync(string email)
        {
            try
            {
                var result = await SendOTPAsync(email);
                return result.Success;
            }
            catch
            {
                return false;
            }
        }

        private string GenerateOTP()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        private async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            // Get settings from configuration or environment variables
            var smtpSettings = _configuration.GetSection("SmtpSettings");
            var smtpServer = smtpSettings["Server"] ?? "smtp.gmail.com";
            var smtpPort = int.Parse(smtpSettings["Port"] ?? "587");
            
            // Try to get from environment variables first, then configuration
            var smtpUsername = Environment.GetEnvironmentVariable("SMTP_USERNAME") 
                ?? smtpSettings["Username"] 
                ?? throw new InvalidOperationException("SMTP Username not configured");
            
            var smtpPassword = Environment.GetEnvironmentVariable("SMTP_PASSWORD") 
                ?? smtpSettings["Password"] 
                ?? throw new InvalidOperationException("SMTP Password not configured");
            
            var fromEmail = Environment.GetEnvironmentVariable("SMTP_FROMEMAIL") 
                ?? smtpSettings["FromEmail"] 
                ?? smtpUsername;

            using var client = new SmtpClient(smtpServer, smtpPort)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(smtpUsername, smtpPassword)
            };

            var message = new MailMessage
            {
                From = new MailAddress(fromEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = false
            };
            message.To.Add(toEmail);

            await client.SendMailAsync(message);
        }
    }
}