using AquariumWatch.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AquariumWatch.Data
{
    public class AquariumWatchDbContext : DbContext
    {
        public AquariumWatchDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Aquarium> Aquariums { get; set; } = null!;
    }
}
