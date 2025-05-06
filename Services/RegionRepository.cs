using Microsoft.EntityFrameworkCore;
using MyFirstApi.Data;
using MyFirstApi.Models;

namespace MyFirstApi.Services
{
    public class RegionRepository : IRepository<Region>
    {
        private readonly GameContext _context;

        public RegionRepository(GameContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Region>> GetAllAsync() => await _context.Regions.ToListAsync();

        public async Task<Region> GetByIdAsync(int id) => await _context.Regions.FindAsync(id);

        public async Task AddAsync(Region entity)
        {
            await _context.Regions.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Region entity)
        {
            _context.Regions.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Regions.FindAsync(id);
            if (entity != null)
            {
                _context.Regions.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}