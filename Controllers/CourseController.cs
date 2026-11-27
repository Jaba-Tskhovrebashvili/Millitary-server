using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MillitaryService.DTOs;
using MillitaryService.Services.Interfaces;

namespace MillitaryService.Controllers
{
    [Route("api/courses")]
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

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCourses([FromQuery] string? search)
        {
                var ranks = await this._courseService.GetCourses(search);
                return StatusCode(200, new { success = true, ranks });
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCourses([FromBody] CoursesDto courses)
        {
            await this._courseService.AddCourses(courses);
            return StatusCode(200, new { success = true, message="კურსი წარმატებით დაემატა" });
        }
    }
}
