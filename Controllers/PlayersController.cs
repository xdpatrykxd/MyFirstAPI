using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Models;
using MyFirstApi.Services;

namespace MyFirstApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly IRepository<Player> _repository;

    public PlayersController(IRepository<Player> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Player>>> GetAll() => Ok(await _repository.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Player>> GetById(int id)
    {
        var player = await _repository.GetByIdAsync(id);
        return player == null ? NotFound() : Ok(player);
    }

    [HttpPost]
    public async Task<ActionResult<Player>> Create([FromBody] Player player)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _repository.AddAsync(player);
        return CreatedAtAction(nameof(GetById), new { id = player.Id }, player);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] Player updatedPlayer)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        updatedPlayer.Id = id;
        await _repository.UpdateAsync(updatedPlayer);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}