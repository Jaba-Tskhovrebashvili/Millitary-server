using Microsoft.EntityFrameworkCore;
using MillitaryService.Data;
using MillitaryService.Models;
using MillitaryService.Repositories.Interfaces;

namespace MillitaryService.Repositories.Implementations
{
    public class PersonnelCoursesRepository: IPersonnelCoursesRepository
    {
        private readonly LibraryDbContext _context;
        public PersonnelCoursesRepository(LibraryDbContext context)
        {
            this._context= context;
        }

        public async Task AddAsync(PersonnelCourses personnelCourses)
        {
            await _context.PersonnelCourses.AddAsync(personnelCourses);
        }

        public async Task<List<PersonnelCourses>> GetPersonnelCourses(int personnelId)
        {
            return await _context.PersonnelCourses.
                Where(x => x.PersonnelId == personnelId)
                .Include(x => x.Course)
                .OrderByDescending(x=>x.EnrollmentDate)
                .ToListAsync();
        }

        public void UpdateAsync(PersonnelCourses personnelCourses)
        {
             _context.PersonnelCourses.Update(personnelCourses);
        }
    }
}
