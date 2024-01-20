using AquariumWatch.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace AquariumWatch.Data.Entities
{
    public class Aquarium
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        public double HighTemp { get; set; }
        public double LowTemp { get; set; }
        public AquariumType Type { get; set; }
        [MaxLength(255)]
        public string Description { get; set; } = null!;
    }
}
