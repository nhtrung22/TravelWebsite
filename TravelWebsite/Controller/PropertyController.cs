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
    [Authorize("Owner", "Admin")]
    public class PropertyController : BaseController
    {
        private readonly IPropertyService _propertyService;
        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpPost]
        public async Task<int> Create(CreatePropertyCommand request)
        {
            var result = await _propertyService.Create(request);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdatePropertyCommand request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }
            await _propertyService.Update(id, request);
            return NoContent();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<PaginatedList<PropertyDTO>>> Get([FromQuery] GetPropertiesQuery request)
        {
            var result = await _propertyService.Get(request);
            return result;
        }

        [HttpGet("GetByCity")]
        [AllowAnonymous]
        public async Task<ActionResult<List<PropertyByCityDTO>>> GetByCity()
        {
            var result = await _propertyService.GetByCity();
            return result;
        }

        [HttpGet("GetByType")]
        [AllowAnonymous]
        public async Task<ActionResult<List<PropertyByTypeDTO>>> GetByType()
        {
            var result = await _propertyService.GetByType();
            return result;
        }

        [HttpGet("GetByCurrentUser")]
        public async Task<ActionResult<PaginatedList<PropertyDTO>>> GetByCurrentUser([FromQuery] GetPropertiesQuery request)
        {
            var result = await _propertyService.GetByCurrentUser(request);
            return result;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<PropertyDTO>> Get(int id)
        {
            var result = await _propertyService.Get(id);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _propertyService.Delete(id);
            return NoContent();
        }
    }
}
