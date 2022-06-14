using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelWebsite.Business.Common.Interfaces;
using TravelWebsite.Business.Helpers;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.Business.Models.Queries;
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

        public async Task<PlaceDTO> Create(PlaceDTO place)
        {

            var result = await _context.Places.AddAsync(_mapper.Map<Place>(place));
            _context.SaveChanges();
            return _mapper.Map<PlaceDTO>(result);
        }

        public async Task<PagedList<PlaceDTO>> Get(GetPlacesQuery request)
        {
            var placeList = await _context.Places.ToListAsync();
            if (string.IsNullOrWhiteSpace(request.City)) placeList.Where(item => item.City.CityName == request.City.Trim()).ToList();
            return PagedList<PlaceDTO>.ToPagedList(_mapper.Map<List<PlaceDTO>>(placeList).AsQueryable(),
                request.PageNumber,
                request.PageSize);
        }

        public async Task<int> Delete(int Id)
        {
            var place = await _context.Places.FindAsync(Id);
            _context.Places.Remove(place);
            return await _context.SaveChangesAsync();
        }

        // Get Place by City ID
        public async Task<List<PlaceDTO>> GetPlaceByCity(int CityId)
        {
            var placeList = await _context.Places.ToListAsync();
            var result = from place in placeList
                         where place.CityId == CityId
                         select place;
            return _mapper.Map<List<PlaceDTO>>(result);
        }

        public async Task Update(int id, PlaceDTO place)
        {
            var entitty = await _context.Places.FindAsync(id);
            if (entitty == null) throw new AppException("Not found");
            _mapper.Map(place, entitty);
            _context.Places.Update(entitty);
            _context.SaveChanges();
        }
    }
}
