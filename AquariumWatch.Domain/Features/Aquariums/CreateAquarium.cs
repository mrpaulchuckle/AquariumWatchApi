using AquariumWatch.Data;
using AquariumWatch.Data.Entities;
using AquariumWatch.Data.Enums;
using MediatR;

namespace AquariumWatch.Domain.Features.Aquariums;

public class CreateAquarium
{
    public record Request(string Name, AquariumType Type, string Description, double HighTemp, double LowTemp) : IRequest<Aquarium>;

    internal class Handler(AquariumWatchDbContext dbContext) : IRequestHandler<Request, Aquarium>
    {
        private readonly AquariumWatchDbContext dbContext = dbContext;

        public async Task<Aquarium> Handle(Request request, CancellationToken cancellationToken)
        {
            Aquarium aquarium = new()
            {
                Name = request.Name,
                Type = request.Type,
                Description = request.Description,
                HighTemp = request.HighTemp,
                LowTemp = request.LowTemp
            };

            dbContext.Aquariums.Add(aquarium);

            try
            {
                await dbContext.SaveChangesAsync(cancellationToken);
            }
            catch
            {
                throw;
            }

            return aquarium;
        }
    }
}
