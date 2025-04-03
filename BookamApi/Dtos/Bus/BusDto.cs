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
        public string BusNumber { get; set;} = string.Empty;
        [Required]
        public int Capacity { get; set;}
        [Required]
        public DateTime DepartureTime {get; set;}
        [Required]
        public DateTime ArrivalTime {get; set;} 
    }
}