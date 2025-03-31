using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Dtos.Bus;
using BookamApi.Interfaces;
using BookamApi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace BookamApi.Controllers
{
    [ApiController]
    [Route("api/bus")]
    public class BusController : ControllerBase
    {
        private readonly IBusRepository _busRepo;
        public BusController(IBusRepository busRepo)
        {
            _busRepo = busRepo;
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById ([FromRoute] int id)
        {
            var bus = await _busRepo.GetByIdAsync(id);
            if (bus == null)
            {
                return BadRequest("Invalid BusId");
            }
            return Ok(bus.ToBusDto());
        }
        [HttpPost("create")]
        public async Task<IActionResult> createBus ([FromBody] CreateBusDto createBusDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bus = createBusDto.ToCreateBusDto();
            await _busRepo.CreateAsync(bus);

            return CreatedAtAction(nameof(GetById), new {Id = bus.BusId}, bus.ToBusDto());
        }
    }
}