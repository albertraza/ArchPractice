using Library.Domain.Entities;

namespace Library.Domain.BaseEntity
{
    public class Entity
    {
        public int StateId { get; set; }
        public State State { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
