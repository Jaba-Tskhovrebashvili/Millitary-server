using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MillitaryService.Services.Interfaces;

namespace MillitaryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : Controller
    {
        private readonly ILogger<PositionsController> _logger;
        private readonly IPositionsService _positionsService;
        public PositionsController(ILogger<PositionsController> logger, IPositionsService positionsService)
        {
            this._logger= logger;
            this._positionsService = positionsService;
        }

        [HttpGet("GetPositions")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPositions([FromQuery] string? search)
        {

          var positions = await this._positionsService.GetPositions(search);
          return StatusCode(200, new { success = true, positions });


        }
    }
}
