using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookamApi.Models
{
    public class Bus
    {
        public int BusId { get; set;}
        public string BusNumber { get; set;} = string.Empty;
        public int Capacity { get; set;}

    }
}