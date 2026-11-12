using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MillitaryService.DTOs;
using MillitaryService.Services.Interfaces;

namespace MillitaryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelAssignmentController : Controller
    {
        private readonly ILogger<PersonnelAssignmentController> _logger;
        private readonly IPersonnelAssignmentsService _personnelAssignmentsService;

        public PersonnelAssignmentController(ILogger<PersonnelAssignmentController> logger, IPersonnelAssignmentsService personnelAssignmentsService)
        {
         this._logger = logger;
         this._personnelAssignmentsService = personnelAssignmentsService;
        }

        [HttpGet("Test")]
        public IActionResult Test()
        {
            return Ok("PersonnelAssignment works!");
        }

        [HttpPost("AddPersonnelAssign")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddPersonnelAssign([FromBody] PersonnelAssignmentsDto personnelAssignmentsDto)
        {
            try
            {
                await this._personnelAssignmentsService.AddAssignmentAsync(personnelAssignmentsDto);
                return StatusCode(200, new { success = true, message="აქტიურად დაემატა" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, new { message = ex.Message, success = false });
            }

        }

    }
}
