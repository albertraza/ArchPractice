using Library.Data.DataAccess.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library.Data.DataAccess.Persistence.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public virtual void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public virtual async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public virtual T Get(object id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetAsync(object id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual T SingleOrDefault(Func<T, bool> predicate)
        {
            return _dbContext.Set<T>().SingleOrDefault(predicate);
        }

        public virtual async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(predicate);
        }

        public virtual void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public virtual IEnumerable<T> Where(Func<T, bool> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).ToList();
        }

        public virtual async Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }
    }
}
