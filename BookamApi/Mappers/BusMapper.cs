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
        BusModel = createBusDto.BusModel,
        Capacity = createBusDto.Capacity,
        RouteId = createBusDto.RouteId,
        DepartureTime = createBusDto.DepartureTime,
        ArrivalTime = createBusDto.ArrivalTime,
    };
}
        public static BusDto ToBusDto (this Bus busDto)
        {
            return new BusDto {
                BusId = busDto.BusId,
                BusNumber = busDto.BusNumber,
                Capacity = busDto.Capacity,
                DepartureTime = busDto.DepartureTime,
                ArrivalTime = busDto.ArrivalTime,
                RouteId = busDto.RouteId,
                SeatsRemaining = busDto.SeatsRemaining,
                AvailableSeats = busDto.AvailableSeats,
                BookedSeats = busDto.BookedSeats
            };
        }
    }
}