using AquariumWatch.Data.Enums;

namespace AquariumWatch.Api.Models.Responses
{
    public class AquariumDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double HighTemp { get; set; }
        public double LowTemp { get; set; }
        public double Ph { get; set; }
        public double Ammonia { get; set; }
        public double Nitrite { get; set; }
        public double Nitrate { get; set; }
        public AquariumType Type { get; set; }
    }
}
