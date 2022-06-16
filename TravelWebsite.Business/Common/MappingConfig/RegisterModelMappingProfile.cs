using AutoMapper;
using TravelWebsite.Business.Models.Commands;
using TravelWebsite.DataAccess.Entities;

namespace Business.Common.MappingConfig
{
    public class RegisterModelMappingProfile : Profile
    {
        public RegisterModelMappingProfile()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<User, CreateUserCommand>();
        }
    }
}