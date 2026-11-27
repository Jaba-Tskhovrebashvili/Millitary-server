using MillitaryService.Models;

namespace MillitaryService.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Courses>> CoursesBySearch(string search);
        Task AddCourse(Courses course);
    }
}
