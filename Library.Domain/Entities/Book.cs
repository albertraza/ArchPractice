using Library.Domain.BaseEntity;

namespace Library.Domain.Entities
{
    public class Book : Entity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<AuthorBook> Authors { get; set; }
    }
}
