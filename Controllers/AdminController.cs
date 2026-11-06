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
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("email-verify")]
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
    
    
    
    }
        

}
