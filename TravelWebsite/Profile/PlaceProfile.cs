using AutoMapper;
using TW.DataAccess.Entities;
using TW.DataAccess.DTO;
public class PlaceProfile : Profile
{
    public PlaceProfile()
    {
        CreateMap<Place, PlaceDTO>();
        CreateMap<PlaceDTO, Place>();
    }
}