using AutoMapper;
using DataAccess.Entities;
using DataAccess.DTO;
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDTO>();
        CreateMap<UserDTO, User>();
    }
}