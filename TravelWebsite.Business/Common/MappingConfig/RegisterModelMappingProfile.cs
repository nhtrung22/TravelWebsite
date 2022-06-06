using AutoMapper;
using TravelWebsite.Business.DTO;
using TravelWebsite.Business.JwtModel;
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