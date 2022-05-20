using AutoMapper;
using DataAccess.DTO;
using DataAccess.EF;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<PlaceDTO>> GetAllAsysnc()
        {
            //using (var context = new TravelDbContext())
            //{
            //    return await context.Place.ToListAsync();
            //}
            var listPlace = new List<Place>()
            {

                new Place(){ Address ="a", PlaceName = "b"},
                new Place(){ Address ="c", PlaceName = "d"}
            };
            return _mapper.Map<List<PlaceDTO>>(listPlace);
        }

        public async Task CreatePlace(PlaceDTO placeDto)
        {
            var place = _mapper.Map<Place>(placeDto);
            _context.Place.Add(place);
            await _context.SaveChangesAsync();
        }

    }
}
