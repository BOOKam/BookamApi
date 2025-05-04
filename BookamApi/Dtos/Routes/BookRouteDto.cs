using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookamApi.Dtos.Routes
{
    public class BookRouteDto
    {
        public string Origin {get; set;} = string.Empty;
        public string Destination {get; set;} = string.Empty;
        public string Duration {get; set;} = string.Empty;
        public string Description {get; set;} = string.Empty;
    }
}