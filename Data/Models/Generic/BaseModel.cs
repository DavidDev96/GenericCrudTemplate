namespace GenericCRUDTemplate.Data.Models.Generic
{
    public class BaseModel : IEntityWithId
    {
        public BaseModel()
        {
            UpdatedAt = null;
            CreatedAt = DateTimeOffset.UtcNow;
            Deleted = false;
        }
        public int Id { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public bool Deleted { get; set; }
    }
}
