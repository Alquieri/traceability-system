 

namespace backend.Models
{
    public class Station
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Number { get; set; }

        public Station(string name, int number)
        {
            Id = Guid.NewGuid();
            Name = name;
            Number = number;
        }

            public Station() {}
    }
}