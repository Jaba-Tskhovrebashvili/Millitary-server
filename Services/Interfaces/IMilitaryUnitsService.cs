using MillitaryService.Models;

namespace MillitaryService.Services.Interfaces
{
    public interface IMilitaryUnitsService
    {
        Task<List<MilitaryUnits>> GetMilitaryUnits(string search, int page);
    }
}
