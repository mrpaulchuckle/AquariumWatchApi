using AquariumWatch.Api.Models.Requests;
using AquariumWatch.Api.Models.Responses;
using AquariumWatch.Data.Entities;
using AquariumWatch.Domain.Features.Aquariums;
using AutoMapper;

namespace AquariumWatch.Api.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            MapRequestDtos();
            MapResponseDtos();
        }

        private void MapRequestDtos()
        {
            CreateMap<CreateAquariumRequestDto, CreateAquarium.Request>();
        }

        private void MapResponseDtos()
        {
            CreateMap<Aquarium, AquariumDto>();
        }
    }
}
