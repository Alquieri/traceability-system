namespace backend.Models
{
    public class Part
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public Guid? CurrentStationId { get; set; }


        public Part(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Status = "Aguardando Recebimento";
            CurrentStationId = null;
        }

        
        public Part() { }
    }
}