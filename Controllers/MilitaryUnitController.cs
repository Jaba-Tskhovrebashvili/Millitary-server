using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MillitaryService.Models;
using MillitaryService.Services.Interfaces;

namespace MillitaryService.Controllers
{
    [Route("api/military-units")]
    [ApiController]
    public class MilitaryUnitController : Controller
    {
        private readonly ILogger<MilitaryUnitController> _logger;
        private readonly IMilitaryUnitsService _militaryUnitsService;

        public MilitaryUnitController(ILogger<MilitaryUnitController> logger, IMilitaryUnitsService militaryUnitsService)
        {
            this._logger = logger;
            this._militaryUnitsService = militaryUnitsService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll([FromQuery] string? search,int page)
        {
          var militaryUnits = await this._militaryUnitsService.GetMilitaryUnits(search,page);
          return StatusCode(200, new { success = true, militaryUnits });
        }
    }
}
