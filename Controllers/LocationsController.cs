using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Models;
using MyFirstApi.Services;

namespace MyFirstApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly IRepository<Location> _repository;

        public LocationsController(IRepository<Location> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetAll()
        {
            var locations = await _repository.GetAllAsync();
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetById(int id)
        {
            var location = await _repository.GetByIdAsync(id);
            return location == null ? NotFound() : Ok(location);
        }

        [HttpPost]
        public async Task<ActionResult<Location>> Create([FromBody] Location location)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repository.AddAsync(location);
            return CreatedAtAction(nameof(GetById), new { id = location.Id }, location);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Location updatedLocation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            updatedLocation.Id = id;
            await _repository.UpdateAsync(updatedLocation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}