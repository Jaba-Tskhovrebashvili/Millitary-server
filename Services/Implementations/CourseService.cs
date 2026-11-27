using MillitaryService.DTOs;
using MillitaryService.Models;
using MillitaryService.Repositories.Interfaces;
using MillitaryService.Services.Interfaces;

namespace MillitaryService.Services.Implementations
{
    public class CourseService: ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CourseService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<Courses>> GetCourses(string search)
        {
          return await this._unitOfWork.CourseRepository.CoursesBySearch(search); 
        }

        public async Task AddCourses(CoursesDto coursesDto)
        {
            var course = new Courses {
             Name= coursesDto.Name,
             Description= coursesDto.Description,
             DurationInWeeks = coursesDto.DurationInWeeks,
             IsActive = coursesDto.IsActive
            };
            await this._unitOfWork.CourseRepository.AddCourse(course);
            await this._unitOfWork.SaveChangesAsync();
        }
    }
}
