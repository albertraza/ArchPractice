using Library.Data.DataAccess.Core;
using Library.Data.DataAccess.Core.Contracts;
using Library.Services.Contracts;

namespace Library.Services.Bussiness
{
    public abstract class Service<T> : IService<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IRepository<T> _repository;

        public Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.GetRepository<T>();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<T> DeleteAsync(object id)
        {
            return await _repository.GetAsync(id);
        }

        public virtual async Task<bool> ExistsAsync(object id)
        {
            T entity = await _repository.GetAsync(id);
            return entity != null;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task<T> GetAsync(object id)
        {
            return await _repository.GetAsync(id);
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.SaveChangesAsync();

            return entity;
        }
    }
}
