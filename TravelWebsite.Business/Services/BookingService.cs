using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelWebsite.Business.Common.Interfaces;
using TravelWebsite.Business.Models.Commands;
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

        public async Task<int> Create(CreateBookingCommand request)
        {
            var place = await _context.Places.FindAsync(request.PlaceId);
            Booking entity = new()
            {
                PlaceId = place.Id,
                FromTime = request.FromTime,
                ToTime = request.ToTime,
                NumberOfAdult = request.NumberOfAdult,
                NumberOfKid = request.NumberOfKid,
                Price = request.Price,
                Deposit = request.Deposit,
                PaymentStatus = DataAccess.Enums.PaymentStatus.Pending,
                Status = DataAccess.Enums.BookingStatus.Booking
            };
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

        public async Task Delete(int id)
        {
            var entity = await _context.Bookings.FindAsync(id);
            _context.Bookings.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BookingDTO>> Get()
        {
            var result = await _context.Bookings.Where(item => item.User.Id == _currentUserService.UserId).ToListAsync();
            return _mapper.Map<List<BookingDTO>>(result);
        }

        public async Task<BookingDTO> Get(int id)
        {
            var result = await _context.Bookings.Include(item => item.Place).FirstOrDefaultAsync(item => item.Id == id);
            return _mapper.Map<BookingDTO>(result);
        }

        //public Task<PagedList<BookingDTO>> Get(GetPlacesQuery request)
        //{
        //    throw new NotImplementedException();
        //}

        public Task Update(int id, UpdateBookingCommand request)
        {
            throw new NotImplementedException();
        }
    }
}
