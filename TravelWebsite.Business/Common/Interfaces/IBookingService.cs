using TravelWebsite.Business.Models.Commands;
using TravelWebsite.Business.Models.DTO;

namespace TravelWebsite.Business.Services
{
    public interface IBookingService
    {
        Task<int> Create(CreateBookingCommand request);
        Task Update(int id, UpdateBookingCommand request);
        Task<List<BookingDTO>> Get();
        Task<BookingDTO> Get(int id);
        Task Delete(int id);
    }
}