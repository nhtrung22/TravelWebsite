using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Transactions;
using TravelWebsite.Business.Common.Extensions;
using TravelWebsite.Business.Common.Interfaces;
using TravelWebsite.Business.Models;
using TravelWebsite.Business.Models.Commands;
using TravelWebsite.Business.Models.Commands.CreatePlace;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.Business.Models.Exceptions;
using TravelWebsite.Business.Models.Queries;
using TravelWebsite.DataAccess.EF;
using TravelWebsite.DataAccess.Entities;

namespace TravelWebsite.Business.Services.PlaceService
{

    public class PlaceService : IPlaceService
    {
        private readonly ITravelDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public PlaceService(ITravelDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<int> Create(CreatePlaceCommand request)
        {

            var city = await _context.Cities.FindAsync(request.CityId);
            if (city == null) throw new NotFoundException(nameof(city), request.CityId);
            var placeType = await _context.PlaceTypes.FindAsync(request.PlaceTypeId);
            if (placeType == null) throw new NotFoundException(nameof(placeType), request.PlaceTypeId);
            var currentUser = await _context.Users.FindAsync(_currentUserService.UserId);
            if (currentUser == null) throw new NotFoundException(nameof(currentUser), _currentUserService.UserId);
            using TransactionScope tx = new(TransactionScopeAsyncFlowOption.Enabled);
            Place entity = new()
            {
                Name = request.Name,
                Address = request.Address,
                Discription = request.Description,
                Price = request.Price,
                NumberOfAdults = request.NumberOfAdults,
                NumberOfKids = request.NumberOfKids,
                City = city,
                PlaceType = placeType,
                User = currentUser,
            };
            var result = await _context.Places.AddAsync(entity);
            await _context.SaveChangesAsync();
            foreach (var image in request.PlaceImages)
            {
                TravelWebsite.DataAccess.Entities.PlaceImage placeImage = new()
                {
                    File = image.File,
                    FileName = image.FileName,
                    PlaceId = result.Entity.Id
                };
                await _context.PlaceImages.AddAsync(placeImage);
            }
            await _context.SaveChangesAsync();
            tx.Complete();
            return result.Entity.Id;
        }

        public async Task<PaginatedList<PlaceDTO>> Get(GetPlacesQuery request)
        {
            Expression<Func<Place, bool>> predicate = PredicateBuilder.True<Place>();
            if (!string.IsNullOrWhiteSpace(request.City))
            {
                predicate = predicate.And(item => item.City.Name == request.City.Trim());
            }
            var placeList = await PaginatedList<PlaceDTO>.CreateAsync(_context.Places.Include(item => item.PlaceImages).Where(predicate).ProjectTo<PlaceDTO>(_mapper.ConfigurationProvider), request.PageNumber, request.PageSize);
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
