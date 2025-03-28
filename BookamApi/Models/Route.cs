using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace BookamApi.Models
{
    public class Route
    {
        public int RouteId { get; set; }
        public string Origin {get; set;} = string.Empty;
        public string Destination {get; set;} = string.Empty;
        public string Price {get; set;} = string.Empty;
        public string DepartureTime {get; set;} = string.Empty;
        public string ArrivalTime {get; set;} = string.Empty;
        public DateTime CreatedAt {get; set;}
        public DateTime? UpdatedAt {get; set;}
    }
}