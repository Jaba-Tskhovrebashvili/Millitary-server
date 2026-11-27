using MillitaryService.DTOs;
using MillitaryService.Models;

namespace MillitaryService.Services.Interfaces
{
    public interface IPersonnelCoursesService
    {
        Task AddAsync(PersonnelCoursesDto newPersonnelCourses);
        Task<List<PersonnelCourses>> GetPersonnelCourses(int personnelId);
        Task UpdateAsync(PersonnelCoursesDto PersonnelCourses, int id);
    }
}
