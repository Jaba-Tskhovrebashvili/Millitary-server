using MailKit.Search;
using Microsoft.EntityFrameworkCore;
using MillitaryService.Data;
using MillitaryService.DTOs;
using MillitaryService.Models;
using MillitaryService.Repositories.Interfaces;

namespace MillitaryService.Repositories.Implementations
{
    public class PersonnelRepository: IPersonnelRepository
    {
        private readonly LibraryDbContext _context;

        public PersonnelRepository(LibraryDbContext context)
        {
            this._context = context;
        }

        public async Task<GetPersonelsDto> GetPersonnels(string search,int page)
        {
            int pageSize = 15;
            try
            {
                var query = this._context.Personnel.Where(x =>
                    string.IsNullOrEmpty(search) ||
                    EF.Functions.Like(
                    (x.Name + " " + x.Surname + " " + x.PersonalNumber).ToLower(), $"%{search.ToLower()}%"));
                var count = await query.CountAsync();
                var personnels = await query
                    .OrderBy(x => x.RankId)
                     .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(a => new Personnel
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Surname = a.Surname,
                        Email = a.Email,
                        RankId = a.RankId,
                        PersonalNumber = a.PersonalNumber,
                        DateOfBirth = a.DateOfBirth,
                        Rank = a.Rank,
                        PhoneNumber = a.PhoneNumber,
                        EnlistmentDate = a.DateOfBirth,
                        IsActive = a.IsActive,
                    }).ToListAsync();
                int totalPages = (int)Math.Ceiling((double)count / pageSize);
                return new GetPersonelsDto
                {
                    Personnels = personnels,
                    totalPages = totalPages
                };
            }
            catch (Exception ex) {
              throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Personnel.AnyAsync(x => x.Email == email);
        }
        
        public async Task<bool> ExistsByPersNumberAsync(string PersonalNumber)
        {
            return await _context.Personnel.AnyAsync(x => x.PersonalNumber == PersonalNumber);
        }

        public async Task<Personnel?> GetByIdAsync(int id)
        {
            return await _context.Personnel.Include(x=>x.Rank).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Personnel personnel)
        {
            await _context.Personnel.AddAsync(personnel);
        }

        public void UpdateAsync(Personnel personnel)
        {
             _context.Personnel.Update(personnel);
        }

        public async Task DeleteAsync(int personId)
        {
            await _context.Personnel.Where(x => x.Id == personId).ExecuteUpdateAsync(
                setters=>setters.SetProperty(a=>a.IsActive,false));
        }
    }
}
