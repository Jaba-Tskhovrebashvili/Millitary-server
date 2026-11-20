using MillitaryService.DTOs;
using MillitaryService.Models;
using MillitaryService.Repositories.Interfaces;
using MillitaryService.Services.Interfaces;

namespace MillitaryService.Services.Implementations
{//PersonnelCoursesDto
    public class PersonnelCoursesService: IPersonnelCoursesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonnelCoursesService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddAsync(PersonnelCoursesDto newPersonnelCourses)
        {
             var createPersonnelCourses = new PersonnelCourses
             {
              PersonnelId=newPersonnelCourses.PersonnelId,
              CourseId=newPersonnelCourses.CourseId,
              EnrollmentDate=newPersonnelCourses.EnrollmentDate,
              CompletionDate = newPersonnelCourses.CompletionDate,
              Result = newPersonnelCourses.Result
             };

                await _unitOfWork.personnelCoursesRepository.AddAsync(createPersonnelCourses);

                await _unitOfWork.SaveChangesAsync();

        }

        public async Task<List<PersonnelCourses>> GetPersonnelCourses(int personnelId)
        {
                var personnelCourses = await _unitOfWork.personnelCoursesRepository.GetPersonnelCourses(personnelId);
                return personnelCourses;
        }

        public async Task UpdateAsync(PersonnelCourses PersonnelCourses)
        {

                _unitOfWork.personnelCoursesRepository.UpdateAsync(PersonnelCourses);

                await _unitOfWork.SaveChangesAsync();
        }
    }
}
