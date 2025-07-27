using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace backend.Models
{
    public class Station
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Number { get; set; }

        public Station(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}