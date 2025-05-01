using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookamApi.Dtos.Bus;
using BookamApi.Interfaces;
using BookamApi.Mappers;
using BookamApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookamApi.Controllers
{
    [ApiController]
    [Route("api/bus")]
    public class BusController : BaseApiController
    {
        private readonly IBusRepository _busRepo;
        public BusController(IBusRepository busRepo)
        {
            _busRepo = busRepo;
        }
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById ([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return ErrorFromModelState(ModelState);
            }
            var bus = await _busRepo.GetByIdAsync(id);
            if (bus == null)
            {
                return Error("Busses Not Found", null, "404");
            }
            return Success(bus.ToBusDto(), "Operation Successful");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create")]
        public async Task<IActionResult> createBus ([FromBody] CreateBusDto createBusDto)
        {
            if (!ModelState.IsValid)
            {
                return ErrorFromModelState(ModelState);
            }

            var bus = createBusDto.ToCreateBusDto();
            await _busRepo.CreateAsync(bus);

            return CreatedSuccess(nameof(GetById), new {Id = bus.BusId}, bus.ToBusDto(), "Bus Created Succesfully");
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var buses = await _busRepo.GetAllAsync();
            if (buses == null)
            {
                return Error("Busses Not Found", null, "404");
            }
            return Success(buses, "Operation Successful");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> updateBus ([FromRoute] int id, [FromBody] UpdateBusDto updateBusDto)
        {
            if (!ModelState.IsValid) return ErrorFromModelState(ModelState);
            
            var busModel = await _busRepo.UpdateAsync(id, updateBusDto);

            if (busModel == null) return Error("Bus not found", null, "404");
            return Success(busModel.ToBusDto(), "Bus Updated");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> deleteBus ([FromRoute] int id)
        {
            if(!ModelState.IsValid) return ErrorFromModelState(ModelState);

            var busModel = await _busRepo.DeleteAsync(id);
            if (busModel == null)
            {
                return Error("Error Deleting Bus", null, "500");
            }
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            return Success(null, "Bus Deleted Succesfully");
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }
    }
}