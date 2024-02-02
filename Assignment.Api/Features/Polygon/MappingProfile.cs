namespace Assignment.Features.Polygons;

using Assignment.Domain;
using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PolygonDto, Polygon>();
        CreateMap<Polygon, PolygonDto>();
    }
}