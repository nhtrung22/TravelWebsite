using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelWebsite.Business.Helpers;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.Business.Models.Jwt;
using TravelWebsite.Business.Services;
using TravelWebsite.DataAccess.EF;
using TravelWebsite.DataAccess.Entities;
using BCr = BCrypt.Net;

namespace Business.Services.PlaceService
{

    public class UserService : IUserService
    {
        private TravelDbContext _context;
        private readonly IMapper _mapper;


        public UserService(TravelDbContext context, IMapper mapper)
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

        public async Task Update(Guid id, UpdateRequest model)
        {
            var user = await GetUserAsync(id);

            // validate
            if (model.Email != user.Email && _context.Users.Any(x => x.Email == model.Email))
                throw new AppException("User with the email '" + model.Email + "' already exists");

            // hash password if it was entered
            if (!string.IsNullOrEmpty(model.Password))
                user.PasswordHash = BCr.BCrypt.HashPassword(model.Password);

            // copy model to user and save
            _mapper.Map(model, user);
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

        public async Task<User> Create(User user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_context.Users.Any(x => x.UserName == user.UserName))
                throw new AppException("Username \"" + user.UserName + "\" is already taken");

            if (_context.Users.Any(x => x.Email == user.Email))
                throw new AppException("Email \"" + user.Email + "\" is already taken");

            if (_context.Users.Any(x => x.PhoneNumber == user.PhoneNumber))
                throw new AppException("PhoneNumber \"" + user.PhoneNumber + "\" is already taken");

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash, GetRandomSalt());

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public async Task Delete(Guid id)
        {
            var user = await GetUserAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}

