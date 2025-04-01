using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Interfaces;

namespace BookamApi.Controllers
{
    public class RouteController
    {
        private readonly IRouteRepository _routeRepo;
        public RouteController(IRouteRepository routeRepo)
        {
            _routeRepo = routeRepo;
        }
    }
}