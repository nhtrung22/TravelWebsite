using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TravelWebsite.Business.Attributes;
using TravelWebsite.Business.Common.Interfaces;
using TravelWebsite.Business.Helpers;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.Business.Models.Queries;

namespace TravelWebsite.API.Controllers
{
    [Authorize("Renter")]
    public class PlaceController : BaseController
    {
        private readonly IPlaceService _placeService;
        private readonly IMapper _mapper;
        public PlaceController(IPlaceService placeService, IMapper mapper)
        {
            _mapper = mapper;
            _placeService = placeService;
        }

        [HttpPost]
        public async Task<PlaceDTO> Create(PlaceDTO placeDTO)
        {
            var result = await _placeService.Create(placeDTO);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PlaceDTO placeDTO)
        {
            if (id != placeDTO.Id)
            {
                return BadRequest();
            }
            await _placeService.Update(id, placeDTO);
            return NoContent();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<PagedList<PlaceDTO>>> Get([FromQuery] GetPlacesQuery request)
        {
            var place = await _placeService.Get(request);
            var metadata = new
            {
                place.TotalCount,
                place.PageSize,
                place.CurrentPage,
                place.HasNext,
                place.HasPrevious,
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return place;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _placeService.Delete(id);
            return NoContent();
        }
    }
}
