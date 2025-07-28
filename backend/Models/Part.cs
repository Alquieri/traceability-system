using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace backend.Models
{
    public class Part
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }

        public Part(string name, String status)
        {
            Id = Guid.NewGuid();
            Name = name;
            Status = status;

        }

        public Part() {}
    }
}