using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelWebsite.Business.Common.Interfaces;
using TravelWebsite.DataAccess.DTO;
using TravelWebsite.DataAccess.EF;

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
