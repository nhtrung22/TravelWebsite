using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelWebsite.Business.Models.Commands;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.Business.Models.Exceptions;
using TravelWebsite.Business.Services;
using TravelWebsite.DataAccess.EF;
using TravelWebsite.DataAccess.Entities;
using BCr = BCrypt.Net;

namespace Business.Services.PlaceService
{

    public class UserService : IUserService
    {
        private readonly ITravelDbContext _context;
        private readonly IMapper _mapper;


        public UserService(ITravelDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var result = await _context.Users.ToListAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(result);
        }


        public async Task<UserDTO> GetById(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(item => item.Id == id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return _mapper.Map<UserDTO>(user);
        }

        public async Task Update(Guid id, UpdateUserCommand request)
        {
            var user = await GetUserAsync(id);

            // validate
            if (request.Email != user.Email && _context.Users.Any(x => x.Email == request.Email))
                throw new AppException("User with the email '" + request.Email + "' already exists");

            // hash password if it was entered
            if (!string.IsNullOrEmpty(request.Password))
                user.PasswordHash = BCr.BCrypt.HashPassword(request.Password);

            // copy model to user and save
            _mapper.Map(request, user);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        private async Task<User> GetUserAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }


        private static string GetRandomSalt()

        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }

        public async Task Create(CreateUserCommand request, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_context.Users.Any(x => x.UserName == request.UserName))
                throw new AppException("Username \"" + request.UserName + "\" is already taken");

            if (_context.Users.Any(x => x.Email == request.Email))
                throw new AppException("Email \"" + request.Email + "\" is already taken");

            if (_context.Users.Any(x => x.PhoneNumber == request.PhoneNumber))
                throw new AppException("PhoneNumber \"" + request.PhoneNumber + "\" is already taken");

            request.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash, GetRandomSalt());
            User entity = new()
            {
                UserName = request.UserName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,

            };
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var user = await GetUserAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}

