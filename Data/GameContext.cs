using Microsoft.EntityFrameworkCore;
using MyFirstApi.Models;

namespace MyFirstApi.Data;

public class GameContext : DbContext
{
    public GameContext(DbContextOptions<GameContext> options) : base(options) { }

    public DbSet<Player> Players { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Region> Regions { get; set; }
}
