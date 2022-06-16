using TravelWebsite.Business.Models.DTO;

namespace TravelWebsite.Business.Services
{
    public interface IBookingService
    {
        Task<int> Create(BookingDTO booking);
        Task Update(int id, BookingDTO place);
        Task<List<BookingDTO>> Get();
        Task<BookingDTO> Get(int id);
        Task<int> Delete(int Id);
    }
}