namespace Assignment.Features.Triangle;

using Assignment.Features.Polygons;
using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PolygonDto, Triangle>();
    }
}