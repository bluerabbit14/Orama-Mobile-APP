using Microsoft.AspNetCore.Mvc;
using Orama_API.Data;
using Orama_API.DTO;
using Orama_API.Interfaces;
using Orama_API.Services;

namespace Orama_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController:ControllerBase
    {
        private readonly IEmailService _emailService;
        public ServiceController(IEmailService emailservice)
        {
            _emailService = emailservice;
        }
        [HttpPost("SendEmailOTP")]
        public async Task<IActionResult> SendEmailOTPAsync([FromBody] EmailOTPRequestDTO request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Email))
                    return BadRequest(new { message = "Email is required" });

                var response = await _emailService.SendOTPAsync(request.Email);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("VerifyEmailOTP")]
        public async Task<IActionResult> VerifyEmailOTPAsync([FromBody] EmailOTPVerifyDTO request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Email))
                    return BadRequest(new { message = "Email is required" });

                if (string.IsNullOrWhiteSpace(request.OTP))
                    return BadRequest(new { message = "OTP is required" });

                var response = await _emailService.VerifyOTPAsync(request.Email, request.OTP);
                return Ok(new
                {
                    message = response ? "Email verified successfully" : "Invalid OTP",
                    success = response
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("ResendEmailOTP")]
        public async Task<IActionResult> ResendEmailOTPAsync([FromBody] EmailOTPRequestDTO request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Email))
                    return BadRequest(new { message = "Email is required" });

                var response = await _emailService.ResendOTPAsync(request.Email);
                return Ok(new
                {
                    message = response ? "OTP resent successfully" : "Failed to resend OTP",
                    success = response
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        // Add this to ServiceController.cs
       [HttpPost("DebugOTP")]
       public async Task<IActionResult> DebugOTPAsync([FromBody] EmailOTPRequestDTO request)
       {
           try
           {
               if (string.IsNullOrWhiteSpace(request.Email))
                   return BadRequest(new { message = "Email is required" });
       
               // Use reflection to access the private _otpStore
               var emailServiceType = _emailService.GetType();
               var otpStoreField = emailServiceType.GetField("_otpStore", 
                   System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
               
               if (otpStoreField != null)
               {
                   var otpStore = otpStoreField.GetValue(_emailService) as Dictionary<string, (string otp, DateTime expiry)>;
                   if (otpStore != null && otpStore.ContainsKey(request.Email))
                   {
                       var (otp, expiry) = otpStore[request.Email];
                       return Ok(new { 
                           message = "OTP found in store", 
                           storedOtp = otp, 
                           expiry = expiry,
                           isExpired = DateTime.UtcNow > expiry,
                           currentTime = DateTime.UtcNow
                       });
                   }
               }
       
               return Ok(new { message = "No OTP found for this email" });
           }
           catch (Exception ex)
           {
               return BadRequest(new { message = ex.Message });
           }
       }
    }
}
