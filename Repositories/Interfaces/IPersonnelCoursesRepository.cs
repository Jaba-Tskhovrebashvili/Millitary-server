using MillitaryService.Models;

namespace MillitaryService.Repositories.Interfaces
{
    public interface IPersonnelCoursesRepository
    {
        Task AddAsync(PersonnelCourses personnelCourses);
        Task<List<PersonnelCourses>> GetPersonnelCourses(int personnelId);
        void UpdateAsync(PersonnelCourses personnelCourses);
    }
}
