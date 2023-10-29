using AquariumWatch.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AquariumWatch.Data
{
    public class AquariumWatchDbContext : DbContext
    {
        public AquariumWatchDbContext(DbContextOptions<AquariumWatchDbContext> options) : base(options)
        {
        }

        public DbSet<Aquarium> Aquariums { get; set; } = null!;
    }
}
