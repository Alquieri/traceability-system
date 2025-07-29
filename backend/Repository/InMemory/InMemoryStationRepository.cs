using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Repository.InMemory
{
    public class InMemoryStationRepository  : IStationRepository
    {
        private readonly List<Station> _station = new(); //Finge que é um banco de dados

           public IEnumerable<Station> GetAll()
            {
                return _station;
            }



        public Station GetById(Guid id)
        {
            var result = _station.FirstOrDefault(p => p.Id == id);

            if (result == null)
                throw new Exception($"Station with id '{id}' not found.");

            return result;
        }

        public void Add(Station station)
        {
            _station.Add(station);

        }

        public void Update(Station station)
        {

            var index = _station.FindIndex(s => s.Id == station.Id);
            if (index != -1)
            _station[index] = station;

        }

        public void Delete(Guid id)
        {
            var station = GetById(id);
            if (station != null)
            _station.Remove(station);
            
        }


    }
}