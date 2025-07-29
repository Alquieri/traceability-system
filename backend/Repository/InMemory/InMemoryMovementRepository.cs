using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Repository.InMemory
{
    public class InMemoryMovementRepository : IMovementRepository
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


        public IEnumerable<Movement> GetByPartId(Guid partId)
        {
            var results = _movements.Where(m => m.PartId == partId);

            if (!results.Any())
                throw new Exception($"No movements found for part id '{partId}'.");

            return results;
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