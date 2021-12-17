using Library.Data.DataAccess.Core.Contracts;

namespace Library.Data.DataAccess.Core
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class;
        Task<bool> SaveChangesAsync();
        bool SaveChanges();
    }
}
