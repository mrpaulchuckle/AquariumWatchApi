using AquariumWatch.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AquariumWatch.Data
{
    public class AquariumWatchDbContext(DbContextOptions<AquariumWatchDbContext> options) : DbContext(options)
    {
        public DbSet<Aquarium> Aquariums { get; set; } = null!;
    }
}
