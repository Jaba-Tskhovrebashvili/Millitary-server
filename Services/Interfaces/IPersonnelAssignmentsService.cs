using MillitaryService.DTOs;
using MillitaryService.Models;

namespace MillitaryService.Services.Interfaces
{
    public interface IPersonnelAssignmentsService
    {
        Task AddAssignmentAsync(PersonnelAssignmentsDto newAssignment);
        Task<List<PersonnelAssignments>> GetPersonnelAssignments(int personnelId);
        Task UpdatePersonnelAssignments(PersonnelAssignmentsDto personnelAssaign, int assignmentId);
    }
}
