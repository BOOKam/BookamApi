using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookamApi.Dtos.Routes
{
    public class CreateRouteDto
    {
        public string Origin {get; set;} = string.Empty;
        public string Destination {get; set;} = string.Empty;
        public string Price {get; set;} = string.Empty;
    }
}