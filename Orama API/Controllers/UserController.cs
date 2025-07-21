using Microsoft.AspNetCore.Mvc;
using Orama_API.DTO;
using Orama_API.Interfaces;

namespace Orama_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService; // Injecting the service to handle user registration
        public UserController(IUserService registerService)
        {
            _userService = registerService; // Initializing the service
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
    }
}
