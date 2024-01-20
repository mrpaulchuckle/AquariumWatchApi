using AquariumWatch.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace AquariumWatch.Api.Models.Requests
{
    public class CreateAquariumRequestDto
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public AquariumType Type { get; set; }

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public double HighTemp { get; set; }

        [Required]
        public double LowTemp { get; set; }
    }
}
