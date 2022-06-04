using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelWebsite.Business.Attributes;
using TravelWebsite.Business.Common.Interfaces;
using TravelWebsite.Business.DTO;

namespace TravelWebsite.API.Controllers
{
    [Authorize("Client")]
    public class PlaceController : BaseController
    {
        private readonly IPlaceService _placeService;
        private readonly IMapper _mapper;
        public PlaceController(IPlaceService placeService, IMapper mapper)
        {
            _mapper = mapper;
            _placeService = placeService;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<List<PlaceDTO>> GetPlaceByCity(int CityId)
        {
            var place = _placeService.GetPlaceByCity(CityId);
            return await place;
        }


    }
}
