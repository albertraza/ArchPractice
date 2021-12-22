using Library.Domain.Entities;

namespace Library.Domain.BaseEntity
{
    public enum EntityStates
    {
        Active = 1,
        Inactive = 2
    };
    public class Entity : IEntity
    {
        public int StateId { get; set; }
        public State State { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
