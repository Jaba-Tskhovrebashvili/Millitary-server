using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MillitaryService.Models;
using MillitaryService.Services.Interfaces;

namespace MillitaryService.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet("GetMilitaryUnits")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetilitaryUnits([FromQuery] string? search,int page)
        {
            try
            {
                var militaryUnits = await this._militaryUnitsService.GetMilitaryUnits(search,page);
                return StatusCode(200, new { success = true, militaryUnits });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, new { message = ex.Message, success = false });
            }

        }
    }
}
