using MillitaryService.Data;
using MillitaryService.Repositories.Interfaces;

namespace MillitaryService.Repositories.Implementations
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly LibraryDbContext _context;
        public IAdminRepository AdminRepository { get; }
        public UnitOfWork(
            LibraryDbContext context,
            IAdminRepository adminRepository)
        {
            this._context = context;
            this.AdminRepository = adminRepository;

        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
