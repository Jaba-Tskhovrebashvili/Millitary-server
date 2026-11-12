using MillitaryService.DTOs;

namespace MillitaryService.Services.Interfaces
{
    public interface IPersonnelAssignmentsService
    {
        Task AddAssignmentAsync(PersonnelAssignmentsDto newAssignment);
    }
}
