using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models; 

namespace backend.Repository
{
    public interface IStationRepository
    {

        Station GetById(Guid id);
        void Add(Station part);
        void Update(Station part);
        void Delete(Guid id);
        
    }
}