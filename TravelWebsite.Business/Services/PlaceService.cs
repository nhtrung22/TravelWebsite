using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq.Expressions;
using TravelWebsite.Business.Common.Extensions;
using TravelWebsite.Business.Common.Interfaces;
using TravelWebsite.Business.Models;
using TravelWebsite.Business.Models.Commands;
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

        public async Task<PlaceDTO> Create(CreatePlaceCommand request)
        {
            var result = await _context.Places.AddAsync(_mapper.Map<Place>(request));
            _context.SaveChanges();
            return _mapper.Map<PlaceDTO>(result);
        }

        public async Task<PaginatedList<PlaceDTO>> Get(GetPlacesQuery request)
        {
            Expression<Func<Place, bool>> predicate = PredicateBuilder.True<Place>();
            if (!string.IsNullOrWhiteSpace(request.City))
            {
                predicate = predicate.And(item => item.City.Name == request.City.Trim());
            }
            var placeList = await PaginatedList<PlaceDTO>.CreateAsync(_context.Places.Where(predicate).ProjectTo<PlaceDTO>(_mapper.ConfigurationProvider), request.PageNumber, request.PageSize);
            return placeList;
        }

        public async Task Delete(int Id)
        {
            var place = await _context.Places.FindAsync(Id);
            _context.Places.Remove(place);
            await _context.SaveChangesAsync();
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
