using MillitaryService.DTOs;

namespace MillitaryService.Helpers.Interfaces
{
    public interface IPersonnelHelper
    {
        Task<PersonnelDto> PersonnelValidate(PersonnelDto personnel);
    }
}
