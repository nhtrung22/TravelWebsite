using AutoMapper;
using TW.DataAccess.Entities;
using TW.DataAccess.DTO;
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDTO>();
        CreateMap<UserDTO, User>();
    }
}