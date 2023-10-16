using AquariumWatch.Api.Constants;
using AquariumWatch.Api.Models.Requests;
using AquariumWatch.Api.Models.Responses;
using AquariumWatch.Data;
using AquariumWatch.Data.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AquariumWatch.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AquariumController : ControllerBase
    {
        private readonly ILogger<AquariumController> _logger;
        private readonly IMapper _mapper;
        private readonly AquariumWatchDbContext _dbContext;

        public AquariumController(ILogger<AquariumController> logger, AquariumWatchDbContext dbContext, IMapper mapper)
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet(RouteConstants.Aquariums)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<AquariumDto>> GetAquariumsAsync(CancellationToken cancellationToken)
        {
            List<Aquarium> entities =  await _dbContext.Aquariums
                .AsNoTracking()
                .OrderBy(a => a.Name)
                .ToListAsync(cancellationToken);

            return _mapper.Map<AquariumDto[]>(entities);
        }

        [HttpPost(RouteConstants.Aquariums)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AquariumDto>> CreateAquariumAsync([FromBody] CreateAquariumRequestDto request, CancellationToken cancellationToken)
        {
            Aquarium aquarium = _mapper.Map<Aquarium>(request);

            _dbContext.Aquariums.Add(aquarium);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return CreatedAtAction(nameof(GetAquariumById), new { id = aquarium.Id }, aquarium);
        }

        [HttpGet(RouteConstants.AquariumById)]
        [ProducesResponseType(typeof(Aquarium), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AquariumDto>> GetAquariumById(int id, CancellationToken cancellationToken)
        {
            Aquarium? aquarium = await _dbContext
                .Aquariums
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

            return aquarium == null ? BadRequest() : _mapper.Map<AquariumDto>(aquarium);
        }

        [HttpDelete(RouteConstants.AquariumById)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteAquarium(int id, CancellationToken cancellationToken)
        {
            Aquarium? aquarium = await _dbContext
                .Aquariums
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (aquarium is not null)
            {
                _dbContext.Aquariums.Remove(aquarium);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return NoContent();
            }

            return BadRequest();
        }
    }
}