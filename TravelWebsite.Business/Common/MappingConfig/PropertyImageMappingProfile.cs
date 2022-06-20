using AutoMapper;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.DataAccess.Entities;

namespace Business.Common.MappingConfig
{
    public class PropertyImageMappingProfile : Profile
    {
        public PropertyImageMappingProfile()
        {
            CreateMap<PropertyImage, PropertyImageDTO>();
            CreateMap<PropertyImageDTO, PropertyImage>();
        }
    }
}
