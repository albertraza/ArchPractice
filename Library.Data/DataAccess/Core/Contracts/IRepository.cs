namespace Library.Data.DataAccess.Core.Contracts
{
    public interface IRepository<T>
    {
        Task AddAsync(T entity);
        void Add(T entity);
        Task UpdateAsync(T entity);
        void Update(T entity);
        Task<T> GetAsync(object id);
        T Get(object id);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> WhereAsync(Func<T, bool> predicate);
        IEnumerable<T> Where(Func<T, bool> predicate);
        Task<T> SingleOrDefaultAsync(Func<T, bool> predicate);
        T SingleOrDefault(Func<T, bool> predicate);
    }
}
