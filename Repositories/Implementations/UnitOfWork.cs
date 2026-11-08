using MillitaryService.Data;
using MillitaryService.Repositories.Interfaces;

namespace MillitaryService.Repositories.Implementations
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly LibraryDbContext _context;
        public IAdminRepository AdminRepository { get; }
        public IPersonnelRepository PersonnelRepository { get; }
        public UnitOfWork(
            LibraryDbContext context,
            IAdminRepository adminRepository,
            IPersonnelRepository personnelRepository)
        {
            this._context = context;
            this.AdminRepository = adminRepository;
            this.PersonnelRepository = personnelRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
