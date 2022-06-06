using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelWebsite.Business.Common.Interfaces;
using TravelWebsite.Business.DTO;
using TravelWebsite.DataAccess.EF;
using TravelWebsite.DataAccess.Entities;

namespace TravelWebsite.Business.Services.PlaceService
{

    public class PlaceService : IPlaceService
    {
        private readonly TravelDbContext _context;

        private readonly IMapper _mapper;

        public PlaceService(TravelDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(PlaceDTO placeDto)
        {
            var place = _mapper.Map<Place>(placeDto);
            _context.Place.Add(place);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PlaceDTO>> Get()
        {
            var placeList = await _context.Place.ToListAsync();
            return _mapper.Map<List<PlaceDTO>>(placeList);
        }

        //public async Task<int> Edit(int Id)
        //{

        //}

        public async Task<int> Delete(int Id)
        {
            var place = await _context.Place.FindAsync(Id);
            _context.Place.Remove(place);
            return await _context.SaveChangesAsync();
        }

        // Get Place by City ID
        public async Task<List<PlaceDTO>> GetPlaceByCity(int CityId)
        {
            var placeList = await _context.Place.ToListAsync();
            var result = from place in placeList
                         where place.CityId == CityId
                         select place;
            return _mapper.Map<List<PlaceDTO>>(result);
        }
    }
}
