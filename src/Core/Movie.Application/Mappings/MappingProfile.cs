using AutoMapper;
using Movie.Application.Features.Cast.Commands;
using Movie.Application.Features.Cast.Results;
using Movie.Application.Features.Category.Commands;
using Movie.Application.Features.Category.Results;
using Movie.Domain.Entities;

namespace Movie.Application.Mappings
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Cast mappings
            CreateMap<Cast, CreateCastCommand>().ReverseMap();
            CreateMap<Cast, UpdateCastCommand>().ReverseMap();
            CreateMap<Cast, GetCastQueryResult>().ReverseMap();
            CreateMap<Cast, GetCastByIdQueryResult>().ReverseMap();

            // Category mappings
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
            CreateMap<Category, GetCategoryQueryResult>().ReverseMap();
            CreateMap<Category, GetCategoryByIdQueryResult>().ReverseMap();
        }
    }
}
