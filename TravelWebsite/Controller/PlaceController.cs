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

        //[HttpPost]
        //public async Task<PlaceDTO> Create(PlaceDTO placeDTO)
        //{
        //    var result = await _placeService.Create(placeDTO);
        //    return await result;
        //}

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<PlaceDTO>> Get()
        {
            var place = _placeService.Get();
            return await place;
        }

        [HttpDelete("(id)")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int Id)
        {
            var place = await _placeService.Delete(Id); 
            return Ok();
        }

        [HttpGet("get-place-by-city")]
        [AllowAnonymous]
        public async Task<List<PlaceDTO>> GetPlaceByCity(int CityId)
        {
            var place = await _placeService.GetPlaceByCity(CityId);
            return place;
        }
    }
}
