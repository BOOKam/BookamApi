using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookamApi.Dtos.Bus
{
    public class CreateBusDto
    {
        public int RouteId {get; set;}
        public string BusNumber { get; set;} = string.Empty;
        public int Capacity { get; set;}
        public DateTime DepartureTime {get; set;}
        public DateTime ArrivalTime {get; set;} 
    }
}