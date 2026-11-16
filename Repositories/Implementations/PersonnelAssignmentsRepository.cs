using Microsoft.EntityFrameworkCore;
using MillitaryService.Data;
using MillitaryService.Models;
using MillitaryService.Repositories.Interfaces;

namespace MillitaryService.Repositories.Implementations
{
    public class PersonnelAssignmentsRepository : IPersonnelAssignmentsRepository
    {
        private readonly LibraryDbContext _context;
        public  PersonnelAssignmentsRepository(LibraryDbContext context)
        {
            this._context=context;
        }

        public async Task AddAsync(PersonnelAssignments personnelAssignments)
        {
            await _context.PersonnelAssignments.AddAsync(personnelAssignments);
        }

        public async Task<PersonnelAssignments?> GetCurrentAssignmentAsync(Int64 personnelId)
        {
            return await _context.PersonnelAssignments
                .FirstOrDefaultAsync(x =>
                    x.PersonnelId == personnelId &&
                    x.IsCurrent==true);
        }

        public async Task<List<PersonnelAssignments>> GetPersonnelAssignments(int personnelId)
        {
            return await _context.PersonnelAssignments.
                Where(x=>x.PersonnelId==personnelId)
                .Include(x=>x.militaryUnit)
                .Include(x=>x.position)
                .ToListAsync();
        }

        public void Update(PersonnelAssignments assignment)
        {
            _context.PersonnelAssignments.Update(assignment);
        }
    }
}
