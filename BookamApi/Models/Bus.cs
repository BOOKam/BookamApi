using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookamApi.Models
{
    public class Bus
    {
        [Key]
        public int BusId { get; set;}
        public int RouteId {get; set;}
        public Routes? routes {get; set;}
        public string BusNumber { get; set;} = string.Empty;
        public string BusModel {get; set;} = string.Empty;
        public int Capacity { get; set;}
        public int SeatsRemaining { get; set;}
        public List<int> BookedSeats {get; set;} =  new();
        public List<int> AvailableSeats {get; set; } = new();
        public DateTime DepartureTime {get; set;}
        public DateTime ArrivalTime {get; set;}

    }
}