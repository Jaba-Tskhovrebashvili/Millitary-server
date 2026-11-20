using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MillitaryService.Services.Interfaces;

namespace MillitaryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankController : Controller
    {
        private readonly ILogger<RankController> _logger;
        private readonly IRankService _rankService;
        public RankController(ILogger<RankController> logger, IRankService rankService)
        {
            this._logger= logger;
            this._rankService= rankService;
        }
        [HttpGet("GetRanks")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetRanks([FromQuery] string? search)
        {
         var ranks = await this._rankService.GetRanks(search);
         return StatusCode(200, new { success = true, ranks });
        }
    }
}
