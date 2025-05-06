using Microsoft.EntityFrameworkCore;
using MyFirstApi.Data;
using MyFirstApi.Models;

namespace MyFirstApi.Services;

public class PlayerRepository : IRepository<Player>
{
    private readonly GameContext _context;

    public PlayerRepository(GameContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Player>> GetAllAsync() => await _context.Players.ToListAsync();

    public async Task<Player> GetByIdAsync(int id) => await _context.Players.FindAsync(id);

    public async Task AddAsync(Player entity)
    {
        await _context.Players.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Player entity)
    {
        _context.Players.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Players.FindAsync(id);
        if (entity != null)
        {
            _context.Players.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
