
using backend.Models;
using backend.Repository;

namespace backend.Services
{

    public class StationService : IStationService
    {
        private readonly IStationRepository _StationRepository;

        public IEnumerable<Station> GetAll()
        {
            return _StationRepository.GetAll();
        }


        public StationService(IStationRepository stationRepository)
        {
            _StationRepository = stationRepository;
        }
        public Station? GetById(Guid id)
        {

            return _StationRepository.GetById(id);
        }

        public void Create(Station station)
        {

            _StationRepository.Add(station);
        }


        public void Update(Station station)
        {

            _StationRepository.Update(station);
        }

        public void Delete(Guid id)
        {

            _StationRepository.Delete(id);
        }
    }
}

