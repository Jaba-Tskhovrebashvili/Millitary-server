using MillitaryService.DTOs;
using MillitaryService.Models;

namespace MillitaryService.Services.Interfaces
{
    public interface IPersonnelService
    {
        Task<bool> PersonnelRegister(PersonnelDto personnelDto);
        Task<Personnel> PersonnelProfile(int PersonnelId);
        Task<bool> PersonnelUpdate(PersonnelDto personnelDto, int personnelId);
    }
}
