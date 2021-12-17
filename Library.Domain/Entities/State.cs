using Library.Domain.BaseEntity;

namespace Library.Domain.Entities
{
    public enum EntityState
    {
        Active = 1,
        Inactive = 2,
    };

    public class State : Entity
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
