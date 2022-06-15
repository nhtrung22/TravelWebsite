using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelWebsite.Business.Common.Interfaces;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.DataAccess.EF;
using TravelWebsite.DataAccess.Entities;

namespace TravelWebsite.Business.Services
{
    public class BookingService : IBookingService
    {
        private readonly IMapper _mapper;
        private readonly TravelDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        public BookingService(IMapper mapper, TravelDbContext context, ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<BookingDTO> Create(BookingDTO booking)
        {
            var entity = _mapper.Map<Booking>(booking);
            entity.UserId = _currentUserService.UserId;
            entity.Place = await _context.Places.FindAsync(booking.PlaceId);
            var result = await _context.Bookings.AddAsync(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<BookingDTO>(result.Entity);
        }

        public Task<int> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BookingDTO>> Get()
        {
            var result = await _context.Bookings.Where(item => item.User.Id == _currentUserService.UserId).ToListAsync();
            return _mapper.Map<List<BookingDTO>>(result);
        }

        //public Task<PagedList<BookingDTO>> Get(GetPlacesQuery request)
        //{
        //    throw new NotImplementedException();
        //}

        public Task Update(int id, BookingDTO place)
        {
            throw new NotImplementedException();
        }
    }
}
