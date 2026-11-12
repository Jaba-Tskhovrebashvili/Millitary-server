using MillitaryService.Models;

namespace MillitaryService.Repositories.Interfaces
{
    public interface IPersonnelAssignmentsRepository
    {
        Task AddAsync(PersonnelAssignments personnelAssignments);
        Task<PersonnelAssignments?> GetCurrentAssignmentAsync(Int64 personnelId);
        void Update(PersonnelAssignments assignment);
    }
}
