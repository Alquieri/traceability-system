using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace backend.Models
{
    public class Moviment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PartId { get; set; }
        public Guid StationId { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Responsible { get; set; }

        public Moviment(Guid partId, Guid stationId, string responsible)
        {
            Id = Guid.NewGuid();
            PartId = partId;
            StationId = stationId;
            Responsible = responsible;
            Date = DateTime.UtcNow;
        }

      
    }
}