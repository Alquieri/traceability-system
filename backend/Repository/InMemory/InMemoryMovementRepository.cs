using backend.Models;

namespace backend.Repository.InMemory
{
    public class InMemoryMovementRepository : IMovementRepository
    {
        private readonly List<Movement> _movements = new();

        public IEnumerable<Movement> GetAll()
        {
            return _movements;
        }

        public Movement GetById(Guid id)
        {
            var result = _movements.FirstOrDefault(p => p.Id == id);
            if (result == null)
                throw new Exception($"Movement with id '{id}' not found.");
            return result;
        }


        public IEnumerable<Movement> GetByPartId(Guid partId)
        {
            return _movements.Where(m => m.PartId == partId).ToList();
        }

        public void Add(Movement movement)
        {
            _movements.Add(movement);
        }

        public Movement? GetLastByPart(Guid partId)
        {
            return _movements
                .Where(m => m.PartId == partId)
                .OrderByDescending(m => m.Timestamp) 
                .FirstOrDefault();
        }
    }
}