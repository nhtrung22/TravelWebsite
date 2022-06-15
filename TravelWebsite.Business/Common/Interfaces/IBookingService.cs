using TravelWebsite.Business.Models.DTO;

namespace TravelWebsite.Business.Services
{
    public interface IBookingService
    {
        Task<BookingDTO> Create(BookingDTO booking);
        Task Update(int id, BookingDTO place);
        //Task<PagedList<BookingDTO>> Get(GetPlacesQuery request);
        Task<int> Delete(int Id);
    }
}