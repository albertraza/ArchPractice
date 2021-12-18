namespace Library.Services.Contracts
{
    public interface IService<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> GetAsync(object id);
        Task<T> UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> DeleteAsync(object id);
    }
}
