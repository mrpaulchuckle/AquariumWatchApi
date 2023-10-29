using AquariumWatch.Api.Constants;
using AquariumWatch.Api.Models.Requests;
using AquariumWatch.Api.Models.Responses;
using AquariumWatch.Data.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AquariumWatch.Domain.Features.Aquariums;

namespace AquariumWatch.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AquariumController : ControllerBase
    {
        private readonly ISender sender;
        private readonly IMapper mapper;

        public AquariumController(ISender sender, IMapper mapper)
        {
            this.sender = sender;
            this.mapper = mapper;
        }

        [HttpGet(RouteConstants.Aquariums)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<AquariumDto>> GetAquariumsAsync(CancellationToken cancellationToken)
        {
            IEnumerable<Aquarium> aquariums = await sender.Send(new GetAquariums.Request(), cancellationToken);
            return mapper.Map<AquariumDto[]>(aquariums);
        }

        [HttpPost(RouteConstants.Aquariums)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AquariumDto>> CreateAquariumAsync([FromBody] CreateAquariumRequestDto request, CancellationToken cancellationToken)
        {
            Aquarium aquarium = await sender.Send(mapper.Map<CreateAquarium.Request>(request), cancellationToken);
            return CreatedAtAction(nameof(GetAquariumById), new { id = aquarium.Id }, aquarium);
        }

        [HttpGet(RouteConstants.AquariumById)]
        [ProducesResponseType(typeof(Aquarium), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AquariumDto>> GetAquariumById(int id, CancellationToken cancellationToken)
        {
            Aquarium? aquarium = await sender.Send(new GetAquariumById.Request(id), cancellationToken);
            return aquarium is null ? NotFound() : mapper.Map<AquariumDto>(aquarium);
        }

        [HttpDelete(RouteConstants.AquariumById)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteAquarium(int id, CancellationToken cancellationToken)
        {
            await sender.Send(new DeleteAquariumById.Request(id), cancellationToken);
            return NoContent();
        }
    }
}