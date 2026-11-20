using MillitaryService.Models;

namespace MillitaryService.Repositories.Interfaces
{
    public interface IPositionsRepository
    {
        Task<List<Positions>> GetPositions(string search);
    }
}
