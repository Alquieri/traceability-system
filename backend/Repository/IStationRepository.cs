
using backend.Models; 

namespace backend.Repository
{
    public interface IStationRepository
    {
        IEnumerable<Station> GetAll();
        Station GetById(Guid id);
        void Add(Station station);
        void Update(Station station);
        void Delete(Guid id);

    }
}