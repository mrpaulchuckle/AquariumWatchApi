using AquariumWatch.Data;
using AquariumWatch.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AquariumWatch.Domain.Features.Aquariums;

public class DeleteAquariumById
{
    public record Request(int Id) : IRequest;

    internal class Handler(AquariumWatchDbContext dbContext) : IRequestHandler<Request>
    {
        private readonly AquariumWatchDbContext dbContext = dbContext;

        public async Task Handle(Request request, CancellationToken cancellationToken)
        {
            Aquarium? aquarium = await dbContext.Aquariums.FirstOrDefaultAsync(a => a.Id ==  request.Id, cancellationToken: cancellationToken);

            if (aquarium != null)
            {
                dbContext.Aquariums.Remove(aquarium);
                await dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}

