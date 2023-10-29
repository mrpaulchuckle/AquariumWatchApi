using AquariumWatch.Data;
using AquariumWatch.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AquariumWatch.Domain.Features.Aquariums;

public class GetAquariums
{
    public record Request() : IRequest<IEnumerable<Aquarium>>;

    internal class Handler : IRequestHandler<Request, IEnumerable<Aquarium>>
    {
        private readonly AquariumWatchDbContext dbContext;

        public Handler(AquariumWatchDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Aquarium>> Handle(Request request, CancellationToken cancellationToken)
        {
            return await dbContext.Aquariums
                .AsNoTracking()
                .OrderBy(a => a.Id)
                .ToListAsync(cancellationToken);
        }
    }
}
