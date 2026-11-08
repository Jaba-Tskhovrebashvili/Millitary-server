using Microsoft.EntityFrameworkCore;
using MillitaryService.Data;
using MillitaryService.Models;
using MillitaryService.Repositories.Interfaces;

namespace MillitaryService.Repositories
{
    public class AdminRepository:IAdminRepository
    {
        private readonly LibraryDbContext _context;
        public AdminRepository(LibraryDbContext context)
        {
            this._context= context;
        }

        public async Task<Admin?> GetByEmailAsync(string email)
        {
            return await _context.Admin.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Admin?> GetByIdAsync(int id)
        {
            return await _context.Admin.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Admin admin)
        {
            await _context.Admin.AddAsync(admin);
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Admin
                .AnyAsync(x => x.Email == email);
        }

    }
}
