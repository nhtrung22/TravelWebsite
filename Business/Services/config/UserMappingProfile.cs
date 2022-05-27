using AutoMapper;
using DataAccess.DTO;
using DataAccess.Entities;

namespace Business.Services.config
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
