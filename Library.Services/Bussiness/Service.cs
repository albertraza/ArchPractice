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

        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return entity;
        }

        public async Task<T> DeleteAsync(object id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetAsync(object id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.SaveChangesAsync();

            return entity;
        }
    }
}
