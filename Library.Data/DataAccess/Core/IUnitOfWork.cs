namespace Library.Data.DataAccess.Core
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
        bool SaveChanges();
    }
}
