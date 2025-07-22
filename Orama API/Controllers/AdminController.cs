using Microsoft.AspNetCore.Mvc;
using Orama_API.DTO;
using Orama_API.Interfaces;
using Orama_API.Services;

namespace Orama_API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AdminController:ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService; // Initializing the service
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUserAsync()
        {
            try
            {
                var response = await _adminService.GetAllUserAsync();
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
        
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            try
            {
                var response = await _adminService.GetUserByIdAsync(id);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
        
        [HttpGet("GetByEmail")]
        public async Task<IActionResult> GetUserByEmailAsync([FromQuery] string email)
        {
            try
            {
                var response = await _adminService.GetUserByEmailAsync(email);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
        
        [HttpGet("GetByPhone")]
        public async Task<IActionResult> GetUserByPhoneAsync([FromQuery] string phone)
        {
            try
            {
                var response = await _adminService.GetUserByPhoneAsync(phone);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
        
        [HttpPut("AlterStatus/{id}")]
        public async Task<IActionResult> AlterUserStatusAsync(int id)
        {
            try
            {
                var response = await _adminService.AlterUserStatusAsync(id);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
