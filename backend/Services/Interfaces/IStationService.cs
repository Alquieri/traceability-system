using backend.Models;

namespace backend.Services
{
    public interface IStationService
    {
        IEnumerable<Station> GetAll();
        Station? GetById(Guid id);
        void Create(Station station);
        void Update(Station station);
        void Delete(Guid id);
        
    }
}