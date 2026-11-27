using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MillitaryService.DTOs;
using MillitaryService.Models;
using MillitaryService.Services.Interfaces;
namespace MillitaryService.Controllers
{
    [Route("api/personnel/courses")]
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

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddPersonnelCourse([FromBody] PersonnelCoursesDto personnelCoursesDto)
        {
            await this._personnelCoursesService.AddAsync(personnelCoursesDto);
            return StatusCode(200, new { success = true, message = "წარმატებით დაემატა" });
            
        }

        [HttpGet("{personnelId:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPersonnelCourses(int personnelId)
        {
                var personnelCourses = await this._personnelCoursesService.GetPersonnelCourses(personnelId);
                return Ok(new { success = true, personnelCourses });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePersonnelCourse([FromBody] PersonnelCoursesDto personnelCourses,int id)
        {
          await this._personnelCoursesService.UpdateAsync(personnelCourses,id);
          return StatusCode(200, new { success = true, message = "წარმატებით შეიცვალა" });

        }
    }
}
