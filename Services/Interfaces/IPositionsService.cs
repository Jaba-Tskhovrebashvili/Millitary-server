using MillitaryService.Models;

namespace MillitaryService.Services.Interfaces
{
    public interface IPositionsService
    {
        Task<List<Positions>> GetPositions(string? search);
    }
}
