using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace BookamApi.Models
{
    public class Routes
    {
        [Key]
        public int RouteId { get; set; }
        public string Origin {get; set;} = string.Empty;
        public string Destination {get; set;} = string.Empty;
        public int Price {get; set;} 
        public string Duration {get; set;} = string.Empty;
        public string Image {get; set;} = string.Empty;
        public string Description {get; set;} = string.Empty;
        public string Distance {get; set;} = string.Empty;
        public DateTime CreatedAt {get; set;}
        public DateTime? UpdatedAt {get; set;}
        public List<Bus> Buses {get; set;} = new List<Bus>();
    }
}