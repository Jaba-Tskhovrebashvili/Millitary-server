using MillitaryService.Models;

namespace MillitaryService.Repositories.Interfaces
{
    public interface IAdminRepository
    {
        Task<Admin?> GetByEmailAsync(string email);
        Task<Admin?> GetByIdAsync(int id);

        Task AddAsync(Admin admin);

        Task<bool> ExistsByEmailAsync(string email);
    }
}
