using MillitaryService.Models;

namespace MillitaryService.Repositories.Interfaces
{
    public interface IRankRepository
    {
        Task<List<Ranks>> GetRunksBySearch(string search);
    }
}
