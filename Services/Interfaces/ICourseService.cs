using MillitaryService.DTOs;
using MillitaryService.Models;

namespace MillitaryService.Services.Interfaces
{
    public interface ICourseService
    {
        Task<List<Courses>> GetCourses(string search);
        Task AddCourses(CoursesDto coursesDto);
    }
}
