namespace MillitaryService.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IAdminRepository AdminRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
