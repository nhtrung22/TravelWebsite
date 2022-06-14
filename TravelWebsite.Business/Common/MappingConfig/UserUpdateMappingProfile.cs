

using AutoMapper;
using TravelWebsite.DataAccess.Entities;
using TravelWebsite.DataAccess.Entities;
using TravelWebsite.Business.Models.Jwt;

namespace TravelWebsite.Business.Common.MappingConfig
{
    public class UserUpdateMappingProfile : Profile
    {
        public UserUpdateMappingProfile()
        {
            // CreateRequest -> User
            // CreateMap<CreateRequest, User>();

            // UpdateRequest -> User
            CreateMap<UpdateRequest, User>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore both null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null role
                        if (x.DestinationMember.Name == "Role" && src.UserType == null) return false;

                        return true;
                    }
                ));
        }
    }
}