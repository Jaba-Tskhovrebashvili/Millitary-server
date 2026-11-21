using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MillitaryService.DTOs;
using MillitaryService.Services.Implementations;
using MillitaryService.Services.Interfaces;

namespace MillitaryService.Controllers
{
    [Route("api/personnel")]
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

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll([FromQuery] string? search,int page)
        {
                var personnel = await _personnelService.GetPersonnels(search, page);
                return StatusCode(200, new { success = true, personnel });

        }

        [HttpGet("id:int")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PersonnelProfile(int id)
        {
                var personnel = await _personnelService.PersonnelProfile(id);
                return StatusCode(200, new { success = true, personnel });
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PersonnelRegister([FromBody] PersonnelDto personnel)
        {
         await _personnelService.PersonnelRegister(personnel);
         return StatusCode(200, new { success = true, message = "პერსონალი წარმატებით დაემატა" });
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PersonnelUpdate([FromBody] PersonnelDto personnel, int id)
        {

          await _personnelService.PersonnelUpdate(personnel, id);
          return StatusCode(200, new { success = true, message = "პერსონალის მონაცემები წარმატებით შეიცვალა" });

        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PersonnelRemove(int id)
        {
         await _personnelService.PersonnelRemove(id);
         return StatusCode(200, new { success = true, message = "პერსონალს შეუჩერდა სტატუსი" });
        }
    }
}
