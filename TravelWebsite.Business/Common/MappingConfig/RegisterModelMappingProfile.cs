using AutoMapper;
using TravelWebsite.Business.Models.Jwt;
using TravelWebsite.DataAccess.Entities;

namespace Business.Common.MappingConfig
{
    public class RegisterModelMappingProfile : Profile
    {
        public RegisterModelMappingProfile()
        {
            CreateMap<RegisterModel, User>();
            CreateMap<User, RegisterModel>();
        }
    }
}