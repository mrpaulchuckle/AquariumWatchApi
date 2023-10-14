using AquariumWatch.Api.Constants;
using AquariumWatch.Data;
using AquariumWatch.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading;

namespace AquariumWatch.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AquariumController : ControllerBase
    {
        private readonly ILogger<AquariumController> _logger;
        private readonly AquariumWatchDbContext _dbContext;

        public AquariumController(ILogger<AquariumController> logger, AquariumWatchDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet(RouteConstants.Aquariums)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<Aquarium>> GetAquariumsAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Aquariums
                .AsNoTracking()
                .OrderBy(a => a.Name)
                .ToListAsync(cancellationToken);
        }

        [HttpPost(RouteConstants.Aquariums)]
        [ProducesResponseType(typeof(Aquarium), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Aquarium>> CreateAquariumAsync(Aquarium aquarium, CancellationToken cancellationToken)
        {
            _dbContext.Aquariums.Add(aquarium);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return CreatedAtAction(nameof(GetAquariumById), new { id = aquarium.Id }, aquarium);
        }

        [HttpGet(RouteConstants.AquariumById)]
        [ProducesResponseType(typeof(Aquarium), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Aquarium>> GetAquariumById(int id, CancellationToken cancellationToken)
        {
            Aquarium? aquarium = await _dbContext
                .Aquariums
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

            return aquarium == null ? BadRequest() : aquarium;
        }
    }
}