using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Dtos.Bus;

namespace BookamApi.Dtos.Routes
{
    public class RouteDto
    {
        public int RouteId {get; set;}
        public string Origin {get; set;} = string.Empty;
        public string Destination {get; set;} = string.Empty;
        public int Price {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime? UpdatedAt {get; set;}
        public List<BusDto> Buses {get; set;} = new List<BusDto>();
    }
}