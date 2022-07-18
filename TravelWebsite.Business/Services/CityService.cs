using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelWebsite.Business.Common.Interfaces;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.DataAccess.EF;

namespace TravelWebsite.Business.Services
{
    public class CityService : ICityService
    {
        private readonly ITravelDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        public CityService(ITravelDbContext context, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<CityDTO>> Get()
        {
            var cityList = await _context.Cities.ToListAsync();
            return _mapper.Map<List<CityDTO>>(cityList);
        }
    }
}
