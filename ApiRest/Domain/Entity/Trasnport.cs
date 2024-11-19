using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Trasnport : BaseEntity
    {
        public string FlightCarrier { get; set; }
        public string FlightNumber { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }
}