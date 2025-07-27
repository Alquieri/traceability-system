using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models; 

namespace backend.Repository
{
    public interface IPartRepository
    {
        IEnumerable<Part> GetAll();
        Part GetById(Guid id);
        Part GetByName(string Name);
        void Add(Part part);
        void Update(Part part);
        void Delete(Guid id);

    }
}