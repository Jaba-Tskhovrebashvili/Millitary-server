using MillitaryService.Data;
using MillitaryService.Repositories.Interfaces;

namespace MillitaryService.Repositories.Implementations
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly LibraryDbContext _context;
        public IAdminRepository AdminRepository { get; }
        public IPersonnelRepository PersonnelRepository { get; }
        public IRankRepository RankRepository { get; }
        public ICourseRepository CourseRepository { get; }
        public IMilitaryUnitsRepository MilitaryUnitsRepository { get; }
        public UnitOfWork(
            LibraryDbContext context,
            IAdminRepository adminRepository,
            IPersonnelRepository personnelRepository,
            IRankRepository rankRepository,
            ICourseRepository courseRepository,
            IMilitaryUnitsRepository militaryUnitsRepository)
        {
            this._context = context;
            this.AdminRepository = adminRepository;
            this.PersonnelRepository = personnelRepository;
            this.RankRepository = rankRepository;
            this.CourseRepository = courseRepository;
            this.MilitaryUnitsRepository = militaryUnitsRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
