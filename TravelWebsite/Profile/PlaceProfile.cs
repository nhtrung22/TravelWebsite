using AutoMapper;
using TravelWebsite.DataAccess.Entities;
using TravelWebsite.DataAccess.DTO;
public class PlaceProfile : Profile
{
    public PlaceProfile()
    {
        CreateMap<Place, PlaceDTO>();
        CreateMap<PlaceDTO, Place>();
    }
}