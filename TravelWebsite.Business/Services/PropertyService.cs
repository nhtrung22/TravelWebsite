using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Transactions;
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

    public class PropertyService : IPropertyService
    {
        private readonly ITravelDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public PropertyService(ITravelDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<int> Create(CreatePropertyCommand request)
        {

            var city = await _context.Cities.FindAsync(request.CityId);
            if (city == null) throw new NotFoundException(nameof(city), request.CityId);
            var type = await _context.PropertyTypes.FindAsync(request.TypeId);
            if (type == null) throw new NotFoundException(nameof(type), request.TypeId);
            var currentUser = await _context.Users.FindAsync(_currentUserService.UserId);
            if (currentUser == null) throw new NotFoundException(nameof(currentUser), _currentUserService.UserId);
            using TransactionScope tx = new(TransactionScopeAsyncFlowOption.Enabled);
            Property entity = new()
            {
                Name = request.Name,
                Address = request.Address,
                ShortDescription = request.ShortDescription,
                Description = request.Description,
                Distance = request.Distance,
                Price = request.Price,
                NumberOfAdults = request.NumberOfAdults,
                NumberOfKids = request.NumberOfKids,
                NumberOfRooms = request.NumberOfAdults,
                City = city,
                Type = type,
                User = currentUser,
            };
            var result = await _context.Properties.AddAsync(entity);
            await _context.SaveChangesAsync();
            foreach (var image in request.Images)
            {
                TravelWebsite.DataAccess.Entities.PropertyImage propertyImage = new()
                {
                    File = image.File,
                    FileName = image.FileName,
                    PropertyId = result.Entity.Id
                };
                await _context.PropertyImages.AddAsync(propertyImage);
            }
            await _context.SaveChangesAsync();
            tx.Complete();
            return result.Entity.Id;
        }

        public async Task<PaginatedList<PropertyDTO>> Get(GetPropertiesQuery request)
        {
            Expression<Func<Property, bool>> predicate = PredicateBuilder.True<Property>();
            predicate = predicate.And(item => item.Bookings.All(booking => booking.FromTime > request.ToTime || booking.ToTime < request.FromTime));
            if (!string.IsNullOrWhiteSpace(request.City))
            {
                predicate = predicate.And(item => item.City.Name.ToUpper().Contains(request.City.ToUpper()));
            }
            if (!string.IsNullOrWhiteSpace(request.Type))
            {
                predicate = predicate.And(item => item.Type.Name.ToUpper().Contains(request.Type.ToUpper()));
            }
            if (request.NumberOfAdults > 0)
            {
                predicate = predicate.And(item => item.NumberOfAdults >= request.NumberOfAdults);
            }
            if (request.NumberOfKids > 0)
            {
                predicate = predicate.And(item => item.NumberOfAdults >= request.NumberOfKids);
            }
            if (request.MaxPrice > 0)
            {
                predicate = predicate.And(item => item.Price <= request.MaxPrice);
            }
            if (request.MinPrice > 0)
            {
                predicate = predicate.And(item => item.NumberOfAdults >= request.MinPrice);
            }
            if (request.NumberOfRooms > 0)
            {
                predicate = predicate.And(item => item.NumberOfRooms >= request.NumberOfRooms);
            }
            var result = await PaginatedList<PropertyDTO>.CreateAsync(_context.Properties.Include(item => item.Images).Where(predicate).ProjectTo<PropertyDTO>(_mapper.ConfigurationProvider), request.PageNumber, request.PageSize);
            return result;
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Properties.FindAsync(id);
            if (entity == null) throw new NotFoundException(nameof(entity), id);
            _context.Properties.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, UpdatePropertyCommand request)
        {
            var entity = await _context.Properties.FindAsync(id);
            if (entity == null) throw new NotFoundException(nameof(entity), id);
            entity.Address = request.Address;
            entity.Description = request.Description;
            entity.ShortDescription = request.ShortDescription;
            using TransactionScope tx = new(TransactionScopeAsyncFlowOption.Enabled);
            var result = _context.Properties.Update(entity);
            await _context.SaveChangesAsync();
            _context.PropertyImages.RemoveRange(_context.PropertyImages.Where(item => item.PropertyId == result.Entity.Id));
            foreach (var image in request.Images)
            {
                TravelWebsite.DataAccess.Entities.PropertyImage propertyImage = new()
                {
                    File = image.File,
                    FileName = image.FileName,
                    PropertyId = result.Entity.Id
                };
                await _context.PropertyImages.AddAsync(propertyImage);
            }
            await _context.SaveChangesAsync();
            tx.Complete();
        }

        public async Task<PropertyDTO> Get(int id)
        {
            var result = await _context.Properties.Include(item => item.User).Include(item => item.Bookings).Include(item => item.City).Include(item => item.Type).Include(item => item.Images).FirstOrDefaultAsync(item => item.Id == id);
            return _mapper.Map<PropertyDTO>(result);
        }

        public async Task<PaginatedList<PropertyDTO>> GetByCurrentUser(GetPropertiesQuery request)
        {
            Expression<Func<Property, bool>> predicate = PredicateBuilder.True<Property>();
            if (!string.IsNullOrWhiteSpace(request.City))
            {
                predicate = predicate.And(item => item.City.Name == request.City.Trim());
            }
            if (request.NumberOfAdults > 0)
            {
                predicate = predicate.And(item => item.NumberOfAdults >= request.NumberOfAdults);
            }
            if (request.NumberOfKids > 0)
            {
                predicate = predicate.And(item => item.NumberOfAdults >= request.NumberOfKids);
            }
            if (request.MaxPrice > 0)
            {
                predicate = predicate.And(item => item.Price <= request.MaxPrice);
            }
            if (request.MinPrice > 0)
            {
                predicate = predicate.And(item => item.NumberOfAdults >= request.MinPrice);
            }
            predicate = predicate.And(item => item.UserId == _currentUserService.UserId);
            var result = await PaginatedList<PropertyDTO>.CreateAsync(_context.Properties.Include(item => item.Images).Where(predicate).ProjectTo<PropertyDTO>(_mapper.ConfigurationProvider), request.PageNumber, request.PageSize);
            return result;
        }

        public async Task<List<PropertyByCityDTO>> GetByCity()
        {
            var list = await _context.Properties.Include(item => item.City).ToListAsync();
            if (list.Count == 0) throw new AppException();
            var result = list.GroupBy(item => item.CityId)
                .Select(item => new PropertyByCityDTO { Number = item.ToList().Count, City = _mapper.Map<CityDTO>(item.FirstOrDefault().City) }).ToList();
            return result;

        }

        public async Task<List<PropertyByTypeDTO>> GetByType()
        {
            var list = await _context.Properties.Include(item => item.Type).ToListAsync();
            if (list.Count == 0) throw new AppException();
            var result = list.GroupBy(item => item.PropertyTypeId)
                .Select(item => new PropertyByTypeDTO { Number = item.ToList().Count, Type = _mapper.Map<PropertyTypeDTO>(item.FirstOrDefault().Type) }).ToList();
            return result;
        }
    }
}
