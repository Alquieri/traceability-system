using backend.Models;

namespace backend.Services.Interfaces
{
    public interface IMovementService
    {
     
        IEnumerable<Movement> GetAll();
        IEnumerable<Movement> GetByPartId(Guid partId);
        void Create(Movement movement);
        Movement? GetLastByPart(Guid partId);


    }
}