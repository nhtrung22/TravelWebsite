using AutoMapper;
using DataAccess.DTO;
using DataAccess.Entities;

namespace Business.Services.config
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
