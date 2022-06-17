using Microsoft.AspNetCore.Mvc;
using TravelWebsite.Business.Common.Attributes;
using TravelWebsite.Business.Common.Interfaces;
using TravelWebsite.Business.Models;
using TravelWebsite.Business.Models.Commands;
using TravelWebsite.Business.Models.Commands.CreatePlace;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.Business.Models.Queries;

namespace TravelWebsite.API.Controllers
{
    [Authorize("Owner")]
    public class PlaceController : BaseController
    {
        private readonly IPlaceService _placeService;
        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpPost]
        public async Task<int> Create(CreatePlaceCommand request)
        {
            var result = await _placeService.Create(request);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdatePlaceCommand request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }
            await _placeService.Update(id, request);
            return NoContent();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<PaginatedList<PlaceDTO>>> Get([FromQuery] GetPlacesQuery request)
        {
            var place = await _placeService.Get(request);
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
