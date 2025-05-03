using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Dtos.Routes;
using BookamApi.Interfaces;
using BookamApi.Mappers;
using BookamApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookamApi.Controllers
{
    [ApiController]
    [Route("api/route")]
    public class RouteController : BaseApiController
    {
        private readonly IRouteRepository _routeRepo;
        public RouteController(IRouteRepository routeRepo)
        {
            _routeRepo = routeRepo;
        }

        // [Authorize(Roles = "Admin, User")]
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Routes>>> GetAll()
        {
            return await _routeRepo.GetAllRoutesAsync();
        }

        // [Authorize(Roles = "Admin, User")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById ([FromRoute] int id)
        {
            if (!ModelState.IsValid) return ErrorFromModelState(ModelState);
            var route = await _routeRepo.GetByIdAsync(id);
            if (route == null) return Error("No Route", null, "404");
            return Success(route.ToRouteDto(), "Operation Successful");
        }

        // [Authorize(Roles = "Admin")]
        [HttpPost("create")]
        public async Task<IActionResult> createRoute([FromBody] CreateRouteDto create)
        {
            if (!ModelState.IsValid) return ErrorFromModelState(ModelState);
            var route = create.ToCreateRouteDto();
            await _routeRepo.CreateAsync(route);

            return CreatedSuccess(nameof(GetById), new {Id = route.RouteId}, route.ToRouteDto(), "Route Created Successfully");
        }
        // [Authorize(Roles = "Admin")]
        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> updateRoute ([FromRoute] int id, [FromBody] UpdateRouteDto update)
        {
            if (!ModelState.IsValid) return ErrorFromModelState(ModelState);
            var routeModel = await _routeRepo.UpdateAsync(id, update);
            if (routeModel == null) return Error("Route Not Found", null, "404");
            return Success(routeModel.ToRouteDto(), "Route Deleted Successfully");
        }

        // [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> deleteRoute([FromRoute] int id)
        {
            if (!ModelState.IsValid) return ErrorFromModelState(ModelState);
            
            var routeModel = await _routeRepo.DeleteAsync(id);
            if (routeModel == null) return Error("Route Not Found", null, "404");
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            return Success(null, "Route Deleted Succesfully");
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        // [Authorize(Roles = "Admin")]
        [HttpGet("search")]
        public async Task<IActionResult> searchRoute([FromQuery] string? Origin, [FromQuery] string? Destination)
        {
            if (!ModelState.IsValid) return ErrorFromModelState(ModelState);
#pragma warning disable CS8604 // Possible null reference argument.
            var route = await _routeRepo.SearchAsync(Origin, Destination);
#pragma warning restore CS8604 // Possible null reference argument.
            if (route == null) return Error("No Route", null, "404");
            return Success(route.Select(r => r.ToRouteDto()), "Operation Successful");
        }
    }
}