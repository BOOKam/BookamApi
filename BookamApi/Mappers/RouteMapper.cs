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
        public static Routes ToRouteDto (this Routes route)
        {
            return new Routes{
                Origin = route.Origin,
                Destination = route.Destination,
                Price = route.Price
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