using Library.Data.DataAccess.Core;
using Library.Data.DataAccess.Core.Contracts;

namespace Library.Data.DataAccess.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IServiceProvider _serviceProvider;

        public UnitOfWork(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            this._dbContext = dbContext;
            this._serviceProvider = serviceProvider;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return _serviceProvider.GetService(typeof(IRepository<T>)) as IRepository<T>;
        }

        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _dbContext.SaveChangesAsync()) > 0;
        }
    }
}
