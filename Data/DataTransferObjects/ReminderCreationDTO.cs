namespace GenericCRUDTemplate.Data.DataTransferObjects
{
    public class ReminderCreationDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? AdditionalInfo { get; set; } = string.Empty;
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset DateToRemind { get; set; }
    }
}
