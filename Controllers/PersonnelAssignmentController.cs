using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MillitaryService.DTOs;
using MillitaryService.Models;
using MillitaryService.Services.Interfaces;

namespace MillitaryService.Controllers
{
    [Route("api/personnel/assignments")]
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


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddPersonnelAssign([FromBody] PersonnelAssignmentsDto personnelAssignmentsDto)
        {
            await this._personnelAssignmentsService.AddAssignmentAsync(personnelAssignmentsDto);
            return StatusCode(200, new { success = true, message="აქტიურად დაემატა" });
            
    
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPersonnelAssign([FromQuery] int personnelId)
        {
               var personnelAssaignments= await this._personnelAssignmentsService.GetPersonnelAssignments(personnelId);
                return StatusCode(200, new { success = true, personnelAssaignments });
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePersonnelAssign([FromBody] PersonnelAssignmentsDto personnelAssignments,int id)
        {
          await this._personnelAssignmentsService.UpdatePersonnelAssignments(personnelAssignments, id);
          return StatusCode(200, new { success = true, message = "წარმატებით შეიცვალაშ" });
        }

    }
}
