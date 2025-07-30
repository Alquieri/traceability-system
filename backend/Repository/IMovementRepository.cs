
using backend.Models;

namespace backend.Repository
{
    public interface IMovementRepository
    {
        IEnumerable<Movement> GetAll();
      
        IEnumerable<Movement> GetByPartId(Guid partId);

        void Add(Movement movement);

        Movement? GetLastByPart(Guid partId);
    }
}

