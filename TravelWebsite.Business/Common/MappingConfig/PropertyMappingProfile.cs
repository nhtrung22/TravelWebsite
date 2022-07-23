using AutoMapper;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.DataAccess.Entities;

namespace Business.Common.MappingConfig
{
    public class PropertyMappingProfile : Profile
    {
        public PropertyMappingProfile()
        {
            CreateMap<Property, PropertyDTO>()
                .ForMember(des => des.City, act => act.MapFrom(src => src.City.Name))
                .ForMember(des => des.Type, act => act.MapFrom(src => src.Type.Name));
            CreateMap<PropertyDTO, Property>();
        }
    }
}
