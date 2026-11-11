using MillitaryService.DTOs;
using MillitaryService.Models;

namespace MillitaryService.Repositories.Interfaces
{
    public interface IPersonnelRepository
    {
        Task<GetPersonelsDto> GetPersonnels(string search, int page);
        Task<bool> ExistsByEmailAsync(string email);
        Task<bool> ExistsByPersNumberAsync(string PersonalNumber);
        Task<Personnel?> GetByIdAsync(int id);
        Task AddAsync(Personnel personnel);
        void UpdateAsync(Personnel personnel);
        Task DeleteAsync(int personId);
    }
}
