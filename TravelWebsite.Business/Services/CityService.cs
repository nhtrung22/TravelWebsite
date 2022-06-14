using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelWebsite.Business.Common.Interfaces;
using TravelWebsite.DataAccess.EF;
using TravelWebsite.DataAccess.Models.DTO;

namespace TravelWebsite.Business.Services
{
    public class CityService : ICityService
    {
        private readonly TravelDbContext _context;

        private readonly IMapper _mapper;
        public CityService(TravelDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<CityDTO>> Get()
        {
            var cityList = await _context.Cities.ToListAsync();
            return _mapper.Map<List<CityDTO>>(cityList);
        }
    }
}
