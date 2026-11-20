using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MillitaryService.Services.Interfaces;

namespace MillitaryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;
        private readonly ICourseService _courseService;
        public CourseController(ILogger<CourseController> logger, ICourseService courseService)
        {
            this._logger = logger;
            this._courseService = courseService;
        }

        [HttpGet("GetCourses")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCourses([FromQuery] string? search)
        {
                var ranks = await this._courseService.GetCourses(search);
                return StatusCode(200, new { success = true, ranks });
        }
    }
}
