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
            try
            {
                return await this._unitOfWork.MilitaryUnitsRepository.MilitaryUnitsSearch(search, page);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }
}
