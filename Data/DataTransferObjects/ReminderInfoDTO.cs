namespace GenericCRUDTemplate.Data.DataTransferObjects
{
    public record ReminderInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? AddtionalInfo { get; set; } = string.Empty;
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset DateToRemind { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public bool Deleted { get; set; }
    }
}
