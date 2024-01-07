using AquariumWatch.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace AquariumWatch.Api.Models.Requests
{
    public class UpdateAquariumRequestDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public AquariumType Type { get; set; }

        [Required]
        public string Description { get; set; } = null!;
    }
}
