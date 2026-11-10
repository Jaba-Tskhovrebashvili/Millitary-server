using MillitaryService.Models;
using MillitaryService.Repositories.Interfaces;
using MillitaryService.Services.Interfaces;

namespace MillitaryService.Services.Implementations
{
    public class RankService: IRankService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RankService(IUnitOfWork unitOfWork) { 
         this._unitOfWork = unitOfWork;
        }

        public async Task<List<Ranks>> GetRanks(string search)
        {
            try
            {
                return await this._unitOfWork.RankRepository.GetRunksBySearch(search);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }
}
