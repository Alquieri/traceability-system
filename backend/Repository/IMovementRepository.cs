using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Repository
{
    public interface IMovementRepository
    {
        IEnumerable<Movement> GetAll();

        IEnumerable<Movement> GetByPartId(Guid partId);

        void Add(Movement movement);
    }
}

