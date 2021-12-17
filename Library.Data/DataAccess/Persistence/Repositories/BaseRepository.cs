namespace Library.Data.DataAccess.Persistence.Repositories
{
    public class BaseRepository<T> : Repository<T> where T : class
    {
        public BaseRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
