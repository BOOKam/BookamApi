using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Dtos.Routes;
using BookamApi.Interfaces;
using BookamApi.Mappers;
using BookamApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookamApi.Controllers
{
    [ApiController]
    [Route("api/route")]
    public class RouteController : ControllerBase
    {
        private readonly IRouteRepository _routeRepo;
        public RouteController(IRouteRepository routeRepo)
        {
            _routeRepo = routeRepo;
        }
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Routes>>> GetAll()
        {
            return await _routeRepo.GetAllRoutesAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById ([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var route = await _routeRepo.GetByIdAsync(id);
            if (route == null) return NotFound("No Route");
            return Ok(route.ToRouteDto());
        }

        [HttpPost("create")]
        public async Task<IActionResult> createRoute([FromBody] CreateRouteDto create)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var route = create.ToCreateRouteDto();
            await _routeRepo.CreateAsync(route);

            return CreatedAtAction(nameof(GetById), new {Id = route.RouteId}, route.ToRouteDto());
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> updateRoute ([FromRoute] int id, [FromBody] UpdateRouteDto update)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var routeModel = await _routeRepo.UpdateAsync(id, update);
            if (routeModel == null) return NotFound();
            return Ok(routeModel.ToRouteDto());
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> deleteRoute([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var routeModel = await _routeRepo.DeleteAsync(id);
            if (routeModel == null) return StatusCode(500, "Route Not Found");
            return Ok("Route Deleted Succesfully");
        }
        [HttpGet("search")]
        public async Task<IActionResult> searchRoute([FromBody] string? Origin, [FromBody] string? Destination)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
#pragma warning disable CS8604 // Possible null reference argument.
            var route = await _routeRepo.SearchAsync(Origin, Destination);
#pragma warning restore CS8604 // Possible null reference argument.
            if (route == null) return NotFound("No Route");
            return Ok(route.Select(r => r.ToRouteDto()));
        }
    }
}