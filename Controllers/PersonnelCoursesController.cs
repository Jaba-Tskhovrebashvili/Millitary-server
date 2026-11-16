using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MillitaryService.DTOs;
using MillitaryService.Models;
using MillitaryService.Services.Interfaces;
namespace MillitaryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelCoursesController : Controller
    {
        private readonly ILogger<PersonnelCoursesController> _logger;
        private readonly IPersonnelCoursesService _personnelCoursesService;

        public PersonnelCoursesController(ILogger<PersonnelCoursesController> logger,
            IPersonnelCoursesService personnelCoursesService)
        {
            this._logger= logger;
            this._personnelCoursesService= personnelCoursesService;
        }

        [HttpPost("AddPersonnelCourse")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddPersonnelCourse([FromBody] PersonnelCoursesDto personnelCoursesDto)
        {

            try
            {
                await this._personnelCoursesService.AddAsync(personnelCoursesDto);
               return StatusCode(200, new { success = true, message = "წარმატებით დაემატა" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding personnel course");
                return StatusCode(500, new { success = false, message = "სერვერის შეცდომა" });
            }
        }

        [HttpGet("GetPersonnelCourses")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPersonnelCourses([FromQuery] int personnelId)
        {
            try
            {
                var personnelCourses = await this._personnelCoursesService.GetPersonnelCourses(personnelId);
                return Ok(new { success = true, personnelCourses });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting courses for personnel {PersonnelId}", personnelId);
                return StatusCode(500, new { success = false, message = "სერვერის შეცდომა" });
            }
        }

        [HttpPut("UpdatePersonnelCourse")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePersonnelCourse([FromBody] PersonnelCourses personnelCourses)
        {

            try
            {
                await this._personnelCoursesService.UpdateAsync(personnelCourses);

                return StatusCode(200, new { success = true, message = "წარმატებით შეიცვალა" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "სერვერის შეცდომა" });
            }
        }
    }
}
