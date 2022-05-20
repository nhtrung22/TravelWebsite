using AutoMapper;
using DataAccess.Entities;
using DataAccess.DTO;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Place, PlaceDTO>();
        CreateMap<PlaceDTO, Place>();
    }
}