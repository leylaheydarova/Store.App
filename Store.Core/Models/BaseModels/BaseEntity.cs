namespace Store.Core.Models.BaseModels
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public bool isDeleted { get; set; }
    }
}
