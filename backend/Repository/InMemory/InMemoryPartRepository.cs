using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Repository.InMemory
{
    public class InMemoryPartRepository : IPartRepository
    {
        private readonly List<Part> _parts = new(); //Finge que é um banco de dados

           public InMemoryPartRepository()
        {
            _parts.Add(new Part("Peça de Teste Principal")
            {
                Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                CurrentStationId = null, 
                Status = "Aguardando Recebimento"
            });
        }

        public IEnumerable<Part> GetAll()
        {
            return _parts;
        }

        public Part GetById(Guid id)
        {
            var result = _parts.FirstOrDefault(p => p.Id == id);

            if (result == null)
                throw new Exception($"Part with id '{id}' not found.");

            return result;
        }

            public Part? GetByName(string name)
        {
            return _parts.FirstOrDefault(p => p.Name == name);
        }   


        public void Add(Part part)
        {
            _parts.Add(part);
        }

        public void Update(Part part)
        {
            var index = _parts.FindIndex(p => p.Id == part.Id);
            if (index >= 0)
                _parts[index] = part;
        }

        public void Delete(Guid id)
        {
            var part = GetById(id);
            if (part != null)
                _parts.Remove(part);
        }


    }
}