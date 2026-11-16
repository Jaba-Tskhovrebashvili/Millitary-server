using Microsoft.EntityFrameworkCore;
using MillitaryService.Data;
using MillitaryService.Models;
using MillitaryService.Repositories.Interfaces;

namespace MillitaryService.Repositories.Implementations
{
    public class PositionsRepository: IPositionsRepository
    {
        private readonly LibraryDbContext _context;
        public PositionsRepository(LibraryDbContext context)
        {
            this._context = context;
        }

        public async Task<List<Positions>> GetPositions(string search)
        {
            var positions = await this._context.Positions.Where(
             x=> (string.IsNullOrEmpty(search) || EF.Functions.Like(x.Name,$"%{search}%"))    
             ).ToListAsync();

            return positions;
        }
    }

}
