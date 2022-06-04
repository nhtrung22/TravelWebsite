using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelWebsite.Business.Common.Interfaces;
using TravelWebsite.Business.DTO;

namespace TravelWebsite.API.Controllers
{
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
        public async Task<List<PlaceDTO>> Get()
        {
            return await _placeService.Get();
        }


    }
}
