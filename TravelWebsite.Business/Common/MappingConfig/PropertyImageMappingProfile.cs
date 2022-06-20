using AutoMapper;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.DataAccess.Entities;

namespace Business.Common.MappingConfig
{
    public class PlaceImageMappingProfile : Profile
    {
        public PlaceImageMappingProfile()
        {
            CreateMap<Property, PropertyImageDTO>();
            CreateMap<PropertyImageDTO, Property>();
        }
    }
}
