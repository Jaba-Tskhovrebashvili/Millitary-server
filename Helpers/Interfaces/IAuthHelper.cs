using MillitaryService.DTOs;
using MillitaryService.Models;

namespace MillitaryService.Helpers.Interfaces
{
    public interface IAuthHelper
    {
        Task<string> GenerateTokenRegister(AdminDto admin);
        Task<Admin> VerifyJWTToken(string token);
        Task<string> GenerateAdminToken(int adminId);

    }
}
