using Microsoft.EntityFrameworkCore;
using MillitaryService.Data;
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

        public async Task<List<MilitaryUnits>> MilitaryUnitsSearch(string search, int page)
        {
            int pageSize = 15;
            try
            {
                var query = this._context.MilitaryUnits.Where(
                    x => (string.IsNullOrEmpty(search) || EF.Functions.Like(x.Description, $"%{search.ToLower()}%")));
                var count = await query.CountAsync();
                var militaryUnits = await query
                    .OrderBy(x=>x.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(x => new MilitaryUnits
                    {
                        Id = x.Id,
                        Name = x.Name,
                        UnitTypeId = x.UnitTypeId,
                        UnitType = x.UnitType,
                        ParentUnitId = x.ParentUnitId,
                        ParentUnit = null,
                        Description = x.Description,
                        SubUnits = null,
                        IsActive = x.IsActive
                    })
                    .ToListAsync();
                int totalPages = (int)Math.Ceiling((double)count / pageSize);
                return militaryUnits;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
