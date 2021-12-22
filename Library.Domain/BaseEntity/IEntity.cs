using Library.Domain.Entities;

namespace Library.Domain.BaseEntity
{
    public interface IEntity
    {
        int StateId { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
        DateTime? DeletedDate { get; set; }
    }
}
