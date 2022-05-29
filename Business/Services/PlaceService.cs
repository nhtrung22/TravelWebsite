using AutoMapper;
using DataAccess.DTO;
using DataAccess.EF;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace Business.Services.PlaceService
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
        public async Task<List<PlaceDTO>> GetAllAsysnc()
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
                         orderby Place.PlaceName descending
                         select Place;

            //foreach (var Place in result) Console.WriteLine($"{Place.PlaceName}");

            return _mapper.Map<List<PlaceDTO>>(result);
        }




        

    }
}
