using Microsoft.EntityFrameworkCore;
using MillitaryService.Data;
using MillitaryService.Models;
using MillitaryService.Repositories.Interfaces;

namespace MillitaryService.Repositories.Implementations
{
    public class CourseRepository:ICourseRepository
    {
        private readonly LibraryDbContext _context;

        public CourseRepository(LibraryDbContext context)
        {
            this._context = context;
        }

        public async Task<List<Courses>> CoursesBySearch(string search)
        {
                var courses = await this._context.Courses
                    .Where(x => (string.IsNullOrEmpty(search) || EF.Functions.Like(x.Name, $"%{search}%")))
                    .ToListAsync();
                return courses;
        }

        public async Task AddCourse(Courses course)
        {
             await this._context.Courses.AddAsync(course);
        }
    }
}
