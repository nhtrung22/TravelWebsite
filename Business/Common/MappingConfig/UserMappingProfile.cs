using AutoMapper;
using TW.DataAccess.DTO;
using TW.DataAccess.Entities;

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
