using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Dtos.Bus;
using BookamApi.Models;

namespace BookamApi.Mappers
{
    public static class BusMapper
    {
        public static Bus ToCreateBusDto (this CreateBusDto createBusDto)
        {
            return new Bus {
                BusNumber = createBusDto.BusNumber,
                Capacity = createBusDto.Capacity,
                DepartureTime = createBusDto.DepartureTime,
                ArrivalTime = createBusDto.ArrivalTime
            };
        }
    }
}