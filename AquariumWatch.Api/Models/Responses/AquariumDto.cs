using AquariumWatch.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace AquariumWatch.Api.Models.Responses
{
    public class AquariumDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required] 
        public string Description { get; set; } = null!;

        [Required]
        public double HighTemp { get; set; }

        [Required]
        public double LowTemp { get; set; }

        [Required]
        public AquariumType Type { get; set; }

        public double Ph { get; set; }
        public double Ammonia { get; set; }
        public double Nitrite { get; set; }
        public double Nitrate { get; set; }
    }
}
