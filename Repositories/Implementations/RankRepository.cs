using Microsoft.EntityFrameworkCore;
using MillitaryService.Data;
using MillitaryService.Models;
using MillitaryService.Repositories.Interfaces;

namespace MillitaryService.Repositories.Implementations
{
    public class RankRepository: IRankRepository
    {
        private readonly LibraryDbContext _context;

        public RankRepository(LibraryDbContext context)
        {
            this._context = context;
        }

        public async Task<List<Ranks>> GetRunksBySearch(string search)
        {
            try
            {
                var ranks = await this._context.Ranks
                    .Where(x => (string.IsNullOrEmpty(search) || EF.Functions.Like(x.Name, $"%{search}%")))
                    .ToListAsync();
                return ranks;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}
