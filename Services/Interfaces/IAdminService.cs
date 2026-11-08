using MillitaryService.DTOs;
using MillitaryService.Models;

namespace MillitaryService.Services.Interfaces
{
    public interface IAdminService
    {
        Task<bool> VerifyEmailAsync(AdminDto admin);
        bool IsValidEmail(string email);
        Task<bool> AdminRegister(PasswordDto passwordDto, string token);
        Task<Admin> GetProfile(int id);
        Task<AdminSignInResponseDto> AdminSignIn(AdminSignInDto adminSignin);
    }
}
