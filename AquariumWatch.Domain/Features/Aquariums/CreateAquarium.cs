using AquariumWatch.Data;
using AquariumWatch.Data.Entities;
using AquariumWatch.Data.Enums;
using MediatR;

namespace AquariumWatch.Domain.Features.Aquariums;

public class CreateAquarium
{
    public record Request(string Name, AquariumType Type) : IRequest<Aquarium>;

    internal class Handler : IRequestHandler<Request, Aquarium>
    {
        private readonly AquariumWatchDbContext dbContext;

        public Handler(AquariumWatchDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Aquarium> Handle(Request request, CancellationToken cancellationToken)
        {
            Aquarium aquarium = new()
            {
                Name = request.Name,
                Type = request.Type
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
