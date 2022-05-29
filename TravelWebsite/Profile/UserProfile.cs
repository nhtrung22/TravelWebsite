using AutoMapper;
using DataAccess.Entities;
using DataAccess.DTO;
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<Place, PlaceDTO>();
        CreateMap<PlaceDTO, Place>();
    }
}