namespace GenericCRUDTemplate.Data.DataTransferObjects
{
    public class ReminderUpdateDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? AdditionalInfo { get; set; } = string.Empty;
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset DateToRemind { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
