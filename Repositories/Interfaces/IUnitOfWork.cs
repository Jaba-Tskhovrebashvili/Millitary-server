namespace MillitaryService.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IAdminRepository AdminRepository { get; }
        IPersonnelRepository PersonnelRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
