using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Flight : BaseEntity
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }
        public int TansportIDFk { get; set; }
        public Transport Transport { get; set; }
    }
}