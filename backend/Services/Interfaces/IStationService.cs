using backend.Models;

namespace backend.Services
{
    public interface IStationService
    {
        Station? GetById(Guid id);
        void Create(Station part);
        void Update(Station part);
        void Delete(Guid id);
        
    }
}