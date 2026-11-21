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
    

        [HttpGet("my-profile/{adminId}")]
        [Authorize]
        async public Task<IActionResult> GetProfile(int adminId)
        {
                var profile = await this._adminService.GetProfile(adminId);
                return StatusCode(200, new { success = true, profile });
        
        }

        [HttpPost("verify-email")]
        public async Task<IActionResult> VerifyEmail([FromBody] AdminDto admin)
        {
 
                await _adminService.VerifyEmailAsync(admin);

                return StatusCode(200, new { success = true, message = "შეამოწმეთ მეილი" });
        }

        [HttpPost("sign-up")]
        async public Task<IActionResult> SignUp([FromBody]PasswordDto password, [FromQuery] string token)
        {
                await this._adminService.AdminRegister(password, token);
                return StatusCode(200, new { success = true, message = "რეგისტრაცია წარმატებულია" });
        }


        [HttpPost("sign-in")]
        async public Task<IActionResult> SignIn(AdminSignInDto adminSignIn)
        {
                var admin = await this._adminService.AdminSignIn(adminSignIn);
              return StatusCode(200, new { success = true, admin=admin.Admin,token=admin.Token });
        }

    }
        

}
