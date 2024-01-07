using AquariumWatch.Data.Entities;
using AquariumWatch.Data.Enums;
using AquariumWatch.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AquariumWatch.Domain.Features.Aquariums
{
    public class UpdateAquarium
    {
        public record Request(int Id, string Name, AquariumType Type, string Description) : IRequest<Aquarium?>;

        internal class Handler(AquariumWatchDbContext dbContext) : IRequestHandler<Request, Aquarium?>
        {
            private readonly AquariumWatchDbContext dbContext = dbContext;

            public async Task<Aquarium?> Handle(Request request, CancellationToken cancellationToken)
            {
                Aquarium? aquarium = await dbContext.Aquariums.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

                if (aquarium == null)
                {
                    return null;
                }

                aquarium.Name = request.Name;
                aquarium.Description = request.Description;
                aquarium.Type = request.Type;

                try
                {
                    await dbContext.SaveChangesAsync(cancellationToken);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return aquarium;
            }
        }
    }
}
