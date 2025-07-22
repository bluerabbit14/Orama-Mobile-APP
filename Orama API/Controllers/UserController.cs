using Microsoft.AspNetCore.Mvc;
using Orama_API.DTO;
using Orama_API.Interfaces;

namespace Orama_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService; // Initializing the service
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUserAsync(SignUpRequestDTO signUpRequestDto)
        {
            try
            {
                var response = await _userService.RegisterUserAsync(signUpRequestDto);
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
        [HttpPost("Password")]
        public async Task<IActionResult> PasswordUserAsync(ChangePasswordRequestDTO changePasswordRequestDto)
        {
            try
            {
                var response = await _userService.PasswordUserAsync(changePasswordRequestDto);
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
        [HttpPost("EmailRegistered")]
        public async Task<IActionResult> EmailRegisteredAsync(string Email)
        {
            try
            {
                var response = await _userService.EmailRegisteredAsync(Email);
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
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUserAsync(LoginRequestDTO logInRequestDto)
        {
            try
            {
               var response = await _userService.LoginUserAsync(logInRequestDto);
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
        [HttpPut("VerifyEmail/{Email}")]
        public async Task<IActionResult> VerifyUserEmailAsync(string Email)
        {
            try
            {
                 if (string.IsNullOrWhiteSpace(Email))
                 return BadRequest(new { message = "Email is required" });

                var response = await _userService.VerifyUserEmailAsync(Email);
                return Ok(new { message = "Email verified successfully"});
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
        [HttpPut("VerifyPhone/{Phone}")]
        public async Task<IActionResult> VerifyUserPhoneAsync(string Phone)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Phone))
                return BadRequest(new { message = "Phone is required" });

                var response = await _userService.VerifyUserPhoneAsync(Phone);
                return Ok(new { message = "Phone verified successfully" });
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

    }
}
