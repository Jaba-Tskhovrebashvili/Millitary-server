using MillitaryService.DTOs;
using MillitaryService.Models;

namespace MillitaryService.Services.Interfaces
{
    public interface IMilitaryUnitsService
    {
        Task<GetMilitaryUnitsDto> GetMilitaryUnits(string search, int page);
    }
}
