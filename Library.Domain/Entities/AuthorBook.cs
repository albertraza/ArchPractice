using Library.Domain.BaseEntity;

namespace Library.Domain.Entities
{
    public class AuthorBook : Entity
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }

        public Author Author { get; set; }
        public Book Book { get; set; }
    }
}
