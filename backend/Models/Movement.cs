namespace backend.Models
{
    public class Movement
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PartId { get; set; }
        public Guid? OriginStationId { get; set; }
        public Guid DestinationStationId { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string? Responsible { get; set; }

 
        public Movement() { }
    }
}