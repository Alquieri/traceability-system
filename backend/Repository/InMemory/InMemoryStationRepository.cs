
using backend.Models;

namespace backend.Repository.InMemory
{
    public class InMemoryStationRepository  : IStationRepository
    {
        private readonly List<Station> _station = new();

        public InMemoryStationRepository()
        {
            _station.Add(new Station
            {
                Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                Name = "Recebimento",
                Number = 1
            });

            _station.Add(new Station
            {
                Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                Name = "Montagem",
                Number = 2
            });

            _station.Add(new Station
            {
                Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                Name = "Inspeção Final",
                Number = 3
            });
        }
        
           public IEnumerable<Station> GetAll()
        {
            return _station;
        }



        public Station GetById(Guid id)
        {
            var result = _station.FirstOrDefault(p => p.Id == id);

            if (result == null)
                throw new Exception($"Station with id '{id}' not found.");

            return result;
        }

        public void Add(Station station)
        {
            _station.Add(station);

        }

        public void Update(Station station)
        {

            var index = _station.FindIndex(s => s.Id == station.Id);
            if (index != -1)
            _station[index] = station;

        }

        public void Delete(Guid id)
        {
            var station = GetById(id);
            if (station != null)
            _station.Remove(station);
            
        }


    }
}