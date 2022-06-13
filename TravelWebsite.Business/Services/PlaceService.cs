﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelWebsite.Business.Common.Interfaces;
using TravelWebsite.Business.DTO;
using TravelWebsite.Business.Helpers;
using TravelWebsite.DataAccess.EF;
using TravelWebsite.DataAccess.Entities;
using TravelWebsite.DataAccess.Entities.Paging;

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

        public async Task<PlaceDTO> Create(Place place)
        {
            var result = await _context.Places.AddAsync(place);
            _context.SaveChanges();
            return _mapper.Map<PlaceDTO>(result);
        }

        public async Task<PagedList<PlaceDTO>> Get(PlaceParametes placeParametes)
        {
            var placeList = await _context.Places.ToListAsync();
            return PagedList<PlaceDTO>.ToPagedList(_mapper.Map<List<PlaceDTO>>(placeList).AsQueryable(),
                placeParametes.PageNumber,
                placeParametes.PageSize);
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
    }
}
