using AquariumWatch.Data;
using AquariumWatch.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AquariumWatch.Domain.Features.Aquariums;

public class GetAquariumById
{
    public record Request(int AquariumId) : IRequest<Aquarium?>;

    internal class Handler(AquariumWatchDbContext dbContext) : IRequestHandler<Request, Aquarium?> 
    {
        private readonly AquariumWatchDbContext dbContext = dbContext;

        public async Task<Aquarium?> Handle(Request request, CancellationToken cancellationToken)
        {
            return await dbContext.Aquariums
                 .AsNoTracking()
                 .FirstOrDefaultAsync(a => a.Id == request.AquariumId, cancellationToken);
        }
    }
}

