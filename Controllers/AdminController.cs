using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MillitaryService.DTOs;
using MillitaryService.Models;
using MillitaryService.Services.Interfaces;

namespace MillitaryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<AdminController> _logger;

        public AdminController(
            IAdminService adminService,
        ILogger<AdminController> logger) {
            _adminService = adminService;
            _logger = logger;
        }
    

        [HttpGet("myProfile/{adminId}")]
        [Authorize]
        async public Task<IActionResult> GetProfile(int adminId)
        {
            try
            {
                var profile = await this._adminService.GetProfile(adminId);
                return StatusCode(200, new { success = true, profile });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, new { message = ex.Message, success = false });
            }    
        
        }

        [HttpPost("emailVerify")]
        public async Task<IActionResult> VerifyEmail([FromBody] AdminDto admin)
        {
            try
            {
                await _adminService.VerifyEmailAsync(admin);

                return StatusCode(200, new { success = true, message = "შეამოწმეთ მეილი" });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, new { message = ex.Message, success = false });
            }
           
        }

        [HttpPost("signUp")]
        async public Task<IActionResult> AdminRegister([FromBody]PasswordDto password, [FromQuery] string token)
        {
            try
            {
                await this._adminService.AdminRegister(password, token);
                return StatusCode(200, new { success = true, message = "რეგისტრაცია წარმატებულია" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, new { message = ex.Message, success = false });
            }
        }


        [HttpPost("signIn")]
        async public Task<IActionResult> AdminSignIn(AdminSignInDto adminSignIn)
        {
            try {
                var admin = await this._adminService.AdminSignIn(adminSignIn);
              return StatusCode(200, new { success = true, admin=admin.Admin,token=admin.Token });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, new { message = ex.Message, success = false });
            }
        }

    }
        

}
