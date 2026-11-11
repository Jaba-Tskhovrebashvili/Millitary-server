using MillitaryService.DTOs;
using MillitaryService.Models;

namespace MillitaryService.Services.Interfaces
{
    public interface IPersonnelService
    {
        Task<GetPersonelsDto> GetPersonnels(string search, int page);
        Task<Personnel> PersonnelProfile(int PersonnelId);
        Task<bool> PersonnelRegister(PersonnelDto personnelDto);
        Task<bool> PersonnelUpdate(PersonnelDto personnelDto, int personnelId);
        Task<bool> PersonnelRemove(int personnelId);
    }
}
