using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookamApi.Dtos.Bus
{
    public class CreateBusDto
    {
        public string BusNumber { get; set;} = string.Empty;
        public int Capacity { get; set;}
        public string DepartureTime {get; set;} = string.Empty;
        public string ArrivalTime {get; set;} = string.Empty;
    }
}