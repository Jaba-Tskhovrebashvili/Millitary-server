using MillitaryService.Models;

namespace MillitaryService.Repositories.Interfaces
{
    public interface IPersonnelAssignmentsRepository
    {
        Task AddAsync(PersonnelAssignments personnelAssignments);
        Task<PersonnelAssignments?> GetCurrentAssignmentAsync(Int64 personnelId);
        Task<List<PersonnelAssignments>> GetPersonnelAssignments(int personnelId);
        void Update(PersonnelAssignments assignment);
    }
}
