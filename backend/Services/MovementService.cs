using backend.Services.Interfaces;
using backend.Models;
using backend.Repository;

namespace backend.Services
{
    public class MovementService : IMovementService
    {
        private readonly IMovementRepository _MovementRepository;
        public MovementService(IMovementRepository movementRepository)
        {
            _MovementRepository = movementRepository;
        }
            public IEnumerable<Movement> GetAll()
        {
            return _MovementRepository.GetAll();
        }
    
        public IEnumerable<Movement> GetByPartId(Guid partId)
        {
            return _MovementRepository.GetByPartId(partId);
        }

        public void Create(Movement movement)
        {
            _MovementRepository.Add(movement);
        }

        public Movement? GetLastByPart(Guid partId)
        {
            return _MovementRepository.GetLastByPart(partId);
        }
        }
 }
