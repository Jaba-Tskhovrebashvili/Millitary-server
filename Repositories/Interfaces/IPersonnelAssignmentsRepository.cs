using MillitaryService.Models;

namespace MillitaryService.Repositories.Interfaces
{
    public interface IPersonnelAssignmentsRepository
    {
        Task<PersonnelAssignments?> GetByIdAsync(long id);
        Task AddAsync(PersonnelAssignments personnelAssignments);
        Task<PersonnelAssignments?> GetCurrentAssignmentAsync(long personnelId);
        Task<List<PersonnelAssignments>> GetPersonnelAssignments(int personnelId);
        void Update(PersonnelAssignments assignment);
    }
}
