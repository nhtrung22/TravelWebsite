using AutoMapper;
using DataAccess.DTO;
using DataAccess.Entities;

namespace Business.Common.MappingConfig
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
