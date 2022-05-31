using AutoMapper;
using TW.DataAccess.DTO;
using TW.DataAccess.Entities;

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
