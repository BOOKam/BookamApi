using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Dtos.Bus;
using BookamApi.Dtos.Routes;
using BookamApi.Models;

namespace BookamApi.Mappers
{
    public static class RouteMapper
    {
        public static RouteDto ToRouteDto (this Routes route)
        {
            return new RouteDto{
                RouteId = route.RouteId,
                Origin = route.Origin,
                Destination = route.Destination,
                Price = route.Price,
                Buses = route.Buses.Select(c => c.ToBusDto()).ToList()
            };
        }

        public static Routes ToCreateRouteDto(this CreateRouteDto createRoute)
        {
            return new Routes{
                Origin = createRoute.Origin,
                Destination = createRoute.Destination,
                Price = createRoute.Price,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}