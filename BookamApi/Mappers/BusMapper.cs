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
                ArrivalTime = createBusDto.ArrivalTime,
                RouteId = createBusDto.RouteId
            };
        }
        public static Bus ToBusDto (this Bus busDto)
        {
            return new Bus {
                BusId = busDto.BusId,
                BusNumber = busDto.BusNumber,
                Capacity = busDto.Capacity,
                DepartureTime = busDto.DepartureTime,
                ArrivalTime = busDto.ArrivalTime,
                RouteId = busDto.RouteId
            };
        }
    }
}