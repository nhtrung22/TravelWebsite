using AutoMapper;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.DataAccess.Entities;

namespace Business.Common.MappingConfig
{
    public class BookingMappingProfile : Profile
    {
        public BookingMappingProfile()
        {
            CreateMap<Booking, BookingDTO>();
            CreateMap<BookingDTO, Booking>();
        }
    }
}
