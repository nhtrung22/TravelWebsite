﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TravelWebsite.Business.Common.Interfaces;
using TravelWebsite.Business.Context;
using TravelWebsite.Business.DTO;
using TravelWebsite.Business.Helpers;
using TravelWebsite.Business.JwtModel;
using TravelWebsite.Business.Services;
using TravelWebsite.DataAccess.EF;
using TravelWebsite.DataAccess.Entities;
using TravelWebsite.DataAccess.Entities.JwtModel;
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
