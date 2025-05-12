using AirportWebLab.Models;
using Microsoft.AspNetCore.Mvc;
using AirportWebLab.Repositories;
using AirportWebLab.Services;
using AirportWebLab.Data;

namespace AirportWebLab.Controllers
{
    // Controllers/AircraftsController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class AircraftsController : ControllerBase
    {
        private readonly AircraftService _service;

        public AircraftsController(AircraftService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var aircraft = await _service.GetByIdAsync(id);
            return aircraft == null ? NotFound() : Ok(aircraft);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAircraftDto dto)
        {
            var aircraft = new Aircraft
            {
                Model = dto.Model,
                Capacity = dto.Capacity,
                ManufacturerId = dto.ManufacturerId,
                CompanyId = dto.CompanyId
            };

            await _service.AddAsync(aircraft);
            return CreatedAtAction(nameof(Get), new { id = aircraft.Id }, aircraft);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAircraftDto aircraftDto)
        {
            try
            {
                var aircraft = new Aircraft
                {
                    Id = id,
                    Model = aircraftDto.Model,
                    Capacity = aircraftDto.Capacity,
                    ManufacturerId = aircraftDto.ManufacturerId,
                    CompanyId = aircraftDto.CompanyId
                };

                await _service.UpdateAsync(aircraft);

                return NoContent(); // Повертаємо статус 204, якщо оновлення успішне
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }

}
