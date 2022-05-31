using AutoMapper;
using TravelWebsite.DataAccess.Entities;
using TravelWebsite.DataAccess.DTO;
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDTO>();
        CreateMap<UserDTO, User>();
    }
}