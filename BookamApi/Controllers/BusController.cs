using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Dtos.Bus;
using BookamApi.Interfaces;
using BookamApi.Mappers;
using BookamApi.Models;
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
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById ([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bus = await _busRepo.GetByIdAsync(id);
            if (bus == null)
            {
                return NotFound();
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
        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<Bus>>> GetAll()
        {
            var buses = await _busRepo.GetAllAsync();
            if (buses == null)
            {
                return BadRequest("You've not created any bus yet");
            }
            return Ok(buses);

        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> updateBus ([FromRoute] int id, [FromBody] UpdateBusDto updateBusDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var busModel = await _busRepo.UpdateAsync(id, updateBusDto);

            if (busModel == null) return NotFound();
            return Ok(busModel.ToBusDto());
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> deleteBus ([FromRoute] int id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var busModel = await _busRepo.DeleteAsync(id);
            if (busModel == null)
            {
                return StatusCode(500, "Error deleting Bus");
            }
            return Ok("bus deleted succesfull");
        }
    }
}