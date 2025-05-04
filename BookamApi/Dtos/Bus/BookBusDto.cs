using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookamApi.Dtos.Bus
{
    public class BookBusDto
    {
        public string BusNumber { get; set;} = string.Empty;
        public string BusModel {get; set;} = string.Empty;
    }
}