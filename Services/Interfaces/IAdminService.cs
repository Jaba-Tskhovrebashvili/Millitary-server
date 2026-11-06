using MillitaryService.DTOs;
using MillitaryService.Models;

namespace MillitaryService.Services.Interfaces
{
    public interface IAdminService
    {
        Task<bool> VerifyEmailAsync(AdminDto admin);
        bool IsValidEmail(string email);
    }
}
