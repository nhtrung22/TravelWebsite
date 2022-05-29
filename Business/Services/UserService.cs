using AutoMapper;
using DataAccess.DTO;
using DataAccess.EF;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace Business.Services.PlaceService
{

    public class UserService : IUserService
    {
        private readonly TravelDbContext _context;

        private readonly IMapper _mapper;

        public UserService(TravelDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

      

        // Get all users
        public async Task<List<UserDTO>> GetAllAsysnc()
        {
            var result = await _context.User.ToListAsync();
            return _mapper.Map<List<UserDTO>>(result);
        }

        public async Task Remove(string email)
        {
            // validation todo
            var user = await _context.User.FirstOrDefaultAsync(item => item.Email == email);
            //if (user == null) retu
            _context.User.Remove(user);
            return;
        }

        public async Task<UserDTO> Add(UserDTO user)
        {
            // validation todo
            User userEntity = _mapper.Map<User>(user);
            //userEntity.Password ma hoa
            _context.User.Add(userEntity);
            var result = await _context.User.AddAsync(userEntity);
            return _mapper.Map<UserDTO>(result);
        }

        public async Task<UserDTO> Login(string userName, string password)
        {
            
            //userEntity.Password ma hoa
            var user = await _context.User.FirstOrDefaultAsync(item => item.UserName == userName && item.Password == password);
            string token = "abcxyz";
            //user.Token = token;
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> Update(UserDTO user)
        {
            // validation todo
            User userEntity = await _context.User.FirstOrDefaultAsync(item => item.Email == user.Email);
            userEntity = _mapper.Map<User>(user);
            //userEntity.Password ma hoa
            _context.User.Update(userEntity);
            return _mapper.Map<UserDTO>(userEntity);
        }
    }
}
