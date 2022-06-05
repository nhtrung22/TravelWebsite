using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelWebsite.Business.Common.Interfaces;
using TravelWebsite.Business.DTO;
using TravelWebsite.DataAccess.EF;

namespace TravelWebsite.Business.Services
{
    public class UserService : IUserService
    {
        private readonly TravelDbContext _context;

        private readonly IMapper _mapper;

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var result = await _context.User.ToListAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(result);
        }

        public async Task<UserDTO> GetById(Guid id)
        {
            var user = await _context.User.FirstOrDefaultAsync(item => item.Id == id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return _mapper.Map<UserDTO>(user);
        }
    }
}
