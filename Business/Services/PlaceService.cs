using AutoMapper;
using TW.Business.Common.Interfaces;
using TW.DataAccess.DTO;
using TW.DataAccess.EF;
using TW.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TW.Business.Common.Interfaces;
using TW.DataAccess.EF;

namespace TW.Business.Services.PlaceService
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

        // Get all places
        public async Task<List<PlaceDTO>> Get()
        {
            var placeList = await _context.Place.ToListAsync();
            return _mapper.Map<List<PlaceDTO>>(placeList);
        }


        // Create Place
        public async Task CreatePlace(PlaceDTO placeDto)
        {
            var place = _mapper.Map<Place>(placeDto);
            _context.Place.Add(place);
            await _context.SaveChangesAsync();
        }

        // Sort Descending
        public async Task<List<PlaceDTO>> SortDescending()
        {
            var placeList = await _context.Place.ToListAsync();


            var result = from Place in placeList
                         orderby Place.Name descending
                         select Place;

            //foreach (var Place in result) Console.WriteLine($"{Place.PlaceName}");

            return _mapper.Map<List<PlaceDTO>>(result);
        }
    }
}
