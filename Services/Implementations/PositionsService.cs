using MillitaryService.Models;
using MillitaryService.Repositories.Interfaces;
using MillitaryService.Services.Interfaces;

namespace MillitaryService.Services.Implementations
{
    public class PositionsService: IPositionsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PositionsService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork=unitOfWork;
        }


        public async Task<List<Positions>> GetPositions(string? search)
        { 
          return await this._unitOfWork.positionsRepository.GetPositions(search);     
        }
    }
}
