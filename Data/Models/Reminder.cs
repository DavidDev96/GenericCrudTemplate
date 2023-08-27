using GenericCRUDTemplate.Data.Models.Generic;

namespace GenericCRUDTemplate.Data.Models
{
    public class Reminder : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string? AddtionalInfo { get; set; } = string.Empty;
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset DateToRemind { get; set; }
    }
}
