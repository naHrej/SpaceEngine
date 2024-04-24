
using Microsoft.EntityFrameworkCore;
using SpaceEngine.Models;

namespace SpaceEngine.Data;

public class AppDbContext : DbContext
{
    public DbSet<SpaceObject> SpaceObjects { get; set; } = null!;
}
