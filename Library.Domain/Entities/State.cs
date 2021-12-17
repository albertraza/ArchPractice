namespace Library.Domain.Entities
{
    public enum EntityState
    {
        Active = 1,
        Inactive = 2,
    };

    public class State
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
