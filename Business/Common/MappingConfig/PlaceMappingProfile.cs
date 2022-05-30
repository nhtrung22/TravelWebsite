using AutoMapper;
using DataAccess.DTO;
using DataAccess.Entities;

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
