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
                Duration = route.Duration,
                Image = route.Image,
                Description = route.Description,
                Distance = route.Distance,
                Buses = route.Buses.Select(c => c.ToBusDto()).ToList()
            };
        }

        public static Routes ToCreateRouteDto(this CreateRouteDto createRoute)
        {
            return new Routes{
                Origin = createRoute.Origin,
                Destination = createRoute.Destination,
                Price = createRoute.Price,
                Duration = createRoute.Duration,
                Image = createRoute.Image,
                Description = createRoute.Description,
                Distance = createRoute.Distance,
                CreatedAt = DateTime.UtcNow
            };
        }
        public static BookRouteDto ToBookRouteDto(this Routes route)
        {
            return new BookRouteDto{
                Origin = route.Origin,
                Destination = route.Destination,
                Duration = route.Duration,
                Description = route.Description,
                Price = route.Price
            };
        }
    }
}