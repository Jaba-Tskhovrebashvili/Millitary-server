namespace MillitaryService.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IAdminRepository AdminRepository { get; }
        IPersonnelRepository PersonnelRepository { get; }
        IRankRepository RankRepository { get; }
        ICourseRepository CourseRepository { get; }
        IMilitaryUnitsRepository MilitaryUnitsRepository { get; }
        IPersonnelAssignmentsRepository personnelAssignmentsRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
