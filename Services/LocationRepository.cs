using Microsoft.EntityFrameworkCore;
using MyFirstApi.Data;
using MyFirstApi.Models;

namespace MyFirstApi.Services
{
    public class LocationRepository : IRepository<Location>
    {
        private readonly GameContext _context;

        public LocationRepository(GameContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Location>> GetAllAsync() => await _context.Locations.ToListAsync();

        public async Task<Location> GetByIdAsync(int id) => await _context.Locations.FindAsync(id);

        public async Task AddAsync(Location entity)
        {
            await _context.Locations.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Location entity)
        {
            _context.Locations.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Locations.FindAsync(id);
            if (entity != null)
            {
                _context.Locations.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}