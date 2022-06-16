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
        private readonly IMailService _mailService;
        public BookingService(IMapper mapper, TravelDbContext context, ICurrentUserService currentUserService, IMailService mailService)
        {
            _mapper = mapper;
            _context = context;
            _currentUserService = currentUserService;
            _mailService = mailService;
        }

        public async Task<int> Create(BookingDTO booking)
        {
            var place = await _context.Places.FindAsync(booking.PlaceId);
            var entity = _mapper.Map<Booking>(booking);
            entity.UserId = _currentUserService.UserId;
            entity.Place = place;
            var result = await _context.Bookings.AddAsync(entity);
            await _context.SaveChangesAsync();
            await _mailService.SendEmailAsync(new Models.MailRequest()
            {
                ToEmail = (await _context.Users.FindAsync(place.User.Id)).Email,
                Subject = "Booking",
                Body = "Booking",
            });
            return result.Entity.Id;
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

        public Task<BookingDTO> Get(int id)
        {
            throw new NotImplementedException();
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
