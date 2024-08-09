namespace Store.App.Models.BaseModels
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public bool isDeleted { get; set; }
    }
}
