using MillitaryService.Models;

namespace MillitaryService.Services.Interfaces
{
    public interface IRankService
    {
        Task<List<Ranks>> GetRanks(string search);
    }
}
