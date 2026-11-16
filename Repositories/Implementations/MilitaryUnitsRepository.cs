using Microsoft.EntityFrameworkCore;
using MillitaryService.Data;
using MillitaryService.DTOs;
using MillitaryService.Models;
using MillitaryService.Repositories.Interfaces;

namespace MillitaryService.Repositories.Implementations
{
    public class MilitaryUnitsRepository: IMilitaryUnitsRepository
    {
        private readonly LibraryDbContext _context;
        public MilitaryUnitsRepository(LibraryDbContext context)
        {
            this._context = context;
        }

        public async Task<(List<MilitaryUnits> Items, int TotalCount)> SearchAsync(
            string? search, int page, int pageSize)
        {
            var query = _context.MilitaryUnits.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(x => EF.Functions.Like(x.Description, $"%{search.Trim()}%"));

            var count = await query.CountAsync();

            var items = await query
                .Include(x => x.UnitType)
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, count);
        }
    }
}
