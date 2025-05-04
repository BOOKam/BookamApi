using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookamApi.Dtos.Bus
{
    public class BusDto
    {
        public int BusId { get; set;}
        [Required]
        public int RouteId {get; set;}
        public string BusNumber { get; set;} = string.Empty;
        public string BusModel {get; set;} = string.Empty;
        [Required]
        public int Capacity { get; set;}
        public int SeatsRemaining { get; set; }
        public List<int> BookedSeats {get; set;} =  new();
        public List<int> AvailableSeats {get; set; } = new();
        [Required]
        public DateTime DepartureTime {get; set;}
        [Required]
        public DateTime ArrivalTime {get; set;} 
    }
}