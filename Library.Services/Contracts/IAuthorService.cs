using Library.Domain.Entities;

namespace Library.Services.Contracts
{
    public interface IAuthorService : IService<Author>
    {
        Task<IEnumerable<Author>> GetAllAsync(string fullName);
    }
}
