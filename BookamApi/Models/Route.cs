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
        public string Origin {get; set;}
        public string Destination {get; set;}
        public string Price {get; get;}
        public string DepartureTime {get; set;}
        public string ArrivalTime {get; set;}
        public DateAndTime CreatedAt {get; set;}
        public DateAndTime UpdatedAt {get; set;}
    }
}