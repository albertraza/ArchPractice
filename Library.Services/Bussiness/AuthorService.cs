using Library.Data.DataAccess.Core;
using Library.Domain.Entities;
using Library.Services.Contracts;

namespace Library.Services.Bussiness
{
    internal class AuthorService : BaseService<Author>, IAuthorService
    {
        public AuthorService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IEnumerable<Author>> GetAllAsync(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName)) return await GetAllAsync();

            return await _unitOfWork.GetRepository<Author>()
                .WhereAsync(author => (author.Firstname.Contains(fullName) || author.Lastname.Contains(fullName)));
        }
    }
}
