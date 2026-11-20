using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MillitaryService.DTOs;
using MillitaryService.Services.Implementations;
using MillitaryService.Services.Interfaces;

namespace MillitaryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelController : Controller
    {
        private readonly ILogger<PersonnelController> _logger;
        private readonly IPersonnelService _personnelService;
        public PersonnelController(ILogger<PersonnelController> logger, IPersonnelService personnelService)
        {
            this._logger = logger;
            this._personnelService = personnelService;
        }

        [HttpGet("GetPersonnels")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPersonnels([FromQuery] string? search,int page)
        {
                var personnel = await _personnelService.GetPersonnels(search, page);
                return StatusCode(200, new { success = true, personnel });

        }

        [HttpGet("GetPersonProfile")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PersonnelProfile([FromQuery] int PersonnelId)
        {
                var personnel = await _personnelService.PersonnelProfile(PersonnelId);
                return StatusCode(200, new { success = true, personnel });
        }


        [HttpPost("AddPerson")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PersonnelRegister([FromBody] PersonnelDto personnel)
        {
                await _personnelService.PersonnelRegister(personnel);

                return StatusCode(200, new { success = true, message = "პერსონალი წარმატებით დაემატა" });


        }

        [HttpPut("UpdatePerson/{personnelId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PersonnelUpdate([FromBody] PersonnelDto personnel, int personnelId)
        {

          await _personnelService.PersonnelUpdate(personnel,personnelId);
          return StatusCode(200, new { success = true, message = "პერსონალის მონაცემები წარმატებით შეიცვალა" });

        }

        [HttpDelete("DeletePerson/{personnelId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PersonnelRemove(int personnelId)
        {
         await _personnelService.PersonnelRemove(personnelId);
         return StatusCode(200, new { success = true, message = "პერსონალს შეუჩერდა სტატუსი" });
        }
    }
}
