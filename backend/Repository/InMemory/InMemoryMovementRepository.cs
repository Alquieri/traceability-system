using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Repository.InMemory
{
    public class InMemoryMovementRepository
    {
        private readonly List<Movement> _movements = new(); //Finge que é um banco de dados

        public IEnumerable<Movement> GetAll()
        {
            return _movements;
        }

        public Movement GetById(Guid id)
        {
            var result = _movements.FirstOrDefault(p => p.Id == id);

            if (result == null)
                throw new Exception($"Station with id '{id}' not found.");

            return result;
        }

        public void Add(Movement movement)
        {
            _movements.Add(movement);

        }

        public Movement? GetLastByPart(Guid partId)
        {
            return _movements
            .Where(m => m.PartId == partId)
            .OrderByDescending(m => m.Date)
            .FirstOrDefault();

        }






    }
}