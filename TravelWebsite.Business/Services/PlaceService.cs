using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq.Expressions;
using TravelWebsite.Business.Common.Extensions;
using TravelWebsite.Business.Common.Interfaces;
using TravelWebsite.Business.Models;
using TravelWebsite.Business.Models.Commands;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.Business.Models.Exceptions;
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

        public async Task<int> Create(CreatePlaceCommand request)
        {
            var result = await _context.Places.AddAsync(_mapper.Map<Place>(request));
            _context.SaveChanges();
            return result.Entity.Id;
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

        public async Task Delete(int id)
        {
            var entity = await _context.Places.FindAsync(id);
            if (entity == null) throw new NotFoundException(nameof(entity), id);
            _context.Places.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, UpdatePlaceCommand request)
        {
            var entity = await _context.Places.FindAsync(id);
            if (entity == null) throw new NotFoundException(nameof(entity), id);
            _mapper.Map(request, entity);
            _context.Places.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
