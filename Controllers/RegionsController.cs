using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Models;
using MyFirstApi.Services;

namespace MyFirstApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionsController : ControllerBase
    {
        private readonly IRepository<Region> _repository;

        public RegionsController(IRepository<Region> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Region>>> GetAll()
        {
            var regions = await _repository.GetAllAsync();
            return Ok(regions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Region>> GetById(int id)
        {
            var region = await _repository.GetByIdAsync(id);
            return region == null ? NotFound() : Ok(region);
        }

        [HttpPost]
        public async Task<ActionResult<Region>> Create([FromBody] Region region)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repository.AddAsync(region);
            return CreatedAtAction(nameof(GetById), new { id = region.Id }, region);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Region updatedRegion)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            updatedRegion.Id = id;
            await _repository.UpdateAsync(updatedRegion);
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