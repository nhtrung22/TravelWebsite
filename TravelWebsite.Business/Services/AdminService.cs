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
    public class AdminService : IAdminService
    {
        private readonly IMapper _mapper;
        private readonly ITravelDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMailService _mailService;
        public AdminService(IMapper mapper, ITravelDbContext context, ICurrentUserService currentUserService, IMailService mailService)
        {
            _mapper = mapper;
            _context = context;
            _currentUserService = currentUserService;
            _mailService = mailService;
        }

        public async Task<StatisticsDTO> GetStatistics()
        {
            StatisticsDTO result = new();
            result.NumberOfUsers = await _context.Users.CountAsync();
            result.NumberOfOrders = await _context.Bookings.CountAsync();
            return result;
        }
    }
}
