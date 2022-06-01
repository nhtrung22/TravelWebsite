using AutoMapper;
using TravelWebsite.DataAccess.DTO;
using TravelWebsite.DataAccess.Entities;

namespace Business.Common.MappingConfig
{
    public class PlaceMappingProfile : Profile
    {
        public PlaceMappingProfile()
        {
            CreateMap<Place, PlaceDTO>();
            CreateMap<PlaceDTO, Place>();
        }
    }
}
