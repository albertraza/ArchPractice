using Library.Domain.BaseEntity;

namespace Library.Domain.Entities
{
    public class Author : Entity
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateBorn { get; set; }

        public IEnumerable<AuthorBook> Books { get; set; }
    }
}
