using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelWebsite.Business.Common.Interfaces;
using TravelWebsite.Business.Models.Commands;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.Business.Models.Exceptions;
using TravelWebsite.DataAccess.EF;
using TravelWebsite.DataAccess.Entities;

namespace TravelWebsite.Business.Services
{
    public class BookingService : IBookingService
    {
        private readonly IMapper _mapper;
        private readonly ITravelDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMailService _mailService;
        public BookingService(IMapper mapper, ITravelDbContext context, ICurrentUserService currentUserService, IMailService mailService)
        {
            _mapper = mapper;
            _context = context;
            _currentUserService = currentUserService;
            _mailService = mailService;
        }

        public async Task<int> Create(CreateBookingCommand request)
        {
            var property = await _context.Properties.Include(item => item.User).FirstOrDefaultAsync(item => item.Id == request.PropertyId);
            if (property == null) throw new NotFoundException(nameof(property), request.PropertyId);
            var owner = await _context.Users.FindAsync(property.User.Id);
            if (owner == null) throw new NotFoundException(nameof(owner), property.User.Id);
            var user = await _context.Users.FindAsync(_currentUserService.UserId);
            if (user == null) throw new NotFoundException(nameof(user), _currentUserService.UserId);
            Booking entity = new()
            {
                PropertyId = property.Id,
                FromTime = request.FromTime,
                ToTime = request.ToTime,
                Deposit = request.Deposit,
                PaymentStatus = DataAccess.Enums.PaymentStatus.Pending,
                PaymentMethod = (DataAccess.Enums.PaymentMethod)request.PaymentMethod,
                Status = DataAccess.Enums.BookingStatus.Booked,
                UserId = user.Id,
                Property = property,
            };
            var result = await _context.Bookings.AddAsync(entity);
            await _context.SaveChangesAsync();
            await _mailService.SendEmailAsync(new Models.MailRequest()
            {
                ToEmail = owner.Email,
                Subject = $"Booking at {property.Name} from {request.FromTime.Date.ToString("dd/MM/yyyy")} to {request.ToTime.Date.ToString("dd/MM/yyyy")} by {user.Username}",
                Body = $"User information:\nEmail: {user.Email}\nPhone: {user.PhoneNumber}",
            });
            return result.Entity.Id;
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Bookings.FindAsync(id);
            if (entity == null) throw new NotFoundException(nameof(entity), id);
            _context.Bookings.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BookingDTO>> Get()
        {
            var result = await _context.Bookings.Include(item => item.Property).Where(item => item.User.Id == _currentUserService.UserId).ToListAsync();
            return _mapper.Map<List<BookingDTO>>(result);
        }

        public async Task<BookingDTO> Get(int id)
        {
            var result = await _context.Bookings.Include(item => item.Property).ThenInclude(item => item.City).FirstOrDefaultAsync(item => item.Id == id);
            return _mapper.Map<BookingDTO>(result);
        }

        public async Task Update(int id, UpdateBookingCommand request)
        {
            var entity = await _context.Bookings.FindAsync(id);
            if (entity == null) throw new NotFoundException(nameof(entity), id);
            _mapper.Map(request, entity);
            _context.Bookings.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
