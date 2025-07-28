using System;
using System.Collections.Generic;
using backend.Models;
using backend.Repository;

namespace backend.Services
{
    public class PartService
    {
        private readonly IPartRepository _partRepository;

        public PartService(IPartRepository partRepository)
        {
            _partRepository = partRepository;
        }

        public IEnumerable<Part> GetAll()
        {
            return _partRepository.GetAll();
        }

        public Part? GetById(Guid id)
        {
            return _partRepository.GetById(id);
        }

        public Part? GetByName(string Name)
        {
            return _partRepository.GetByName(Name);
        }

        public void Create(Part part)
        {
            if (string.IsNullOrEmpty(part.Name))
                throw new ArgumentException("Part name cannot be null or empty.", nameof(part.Name));

            if (_partRepository.GetByName(part.Name) != null)
                throw new Exception("A part with this code already exists.");

            _partRepository.Add(part);
        }

        public void Update(Part part)
        {
            _partRepository.Update(part);
        }

        public void Delete(Guid id)
        {
            _partRepository.Delete(id);
        }
    }
}
