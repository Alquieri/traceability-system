using backend.Models;

namespace backend.Services
{
    public interface IPartService
    {
        IEnumerable<Part> GetAll();
        Part? GetById(Guid id);
        Part? GetByName(string name);
        void Create(Part part);
        void Update(Part part);
        void Delete(Guid id);
    }
}
