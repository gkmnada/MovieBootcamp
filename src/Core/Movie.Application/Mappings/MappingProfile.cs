using AutoMapper;
using Movie.Application.Features.Cast.Commands;
using Movie.Application.Features.Cast.Results;
using Movie.Domain.Entities;

namespace Movie.Application.Mappings
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cast, CreateCastCommand>().ReverseMap();
            CreateMap<Cast, UpdateCastCommand>().ReverseMap();
            CreateMap<Cast, GetCastQueryResult>().ReverseMap();
            CreateMap<Cast, GetCastByIdQueryResult>().ReverseMap();
        }
    }
}
