using MillitaryService.DTOs;
using MillitaryService.Models;
using MillitaryService.Repositories.Interfaces;
using MillitaryService.Services.Interfaces;

namespace MillitaryService.Services.Implementations
{
    public class MilitaryUnitsService: IMilitaryUnitsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MilitaryUnitsService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<GetMilitaryUnitsDto> GetMilitaryUnits(string search,int page)
        {
                 int pageSize = 15;

                var (items, count) = await _unitOfWork.MilitaryUnitsRepository
                    .SearchAsync(search, page, pageSize);

                return new GetMilitaryUnitsDto
                {
                    militaryUnits = items,
                    totalPages = (int)Math.Ceiling(count / (double)pageSize),
                    count=count
                };
        }
    }
}
