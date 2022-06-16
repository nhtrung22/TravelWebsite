using Microsoft.AspNetCore.Mvc;
using TravelWebsite.API.Controllers;
using TravelWebsite.Business.Common.Attributes;
using TravelWebsite.Business.Models.Commands;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.Business.Services;

namespace TravelWebsite.API.Controller
{
    [Authorize("Client")]
    public class BookingController : BaseController
    {
        // GET: api/Booking
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public async Task<ActionResult<List<BookingDTO>>> Get()
        {
            return await _bookingService.Get();
        }

        // GET: api/Booking/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<BookingDTO>> Get(int id)
        {
            return await _bookingService.Get(id);
        }

        // POST: api/Booking
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateBookingCommand request)
        {
            var result = await _bookingService.Create(request);
            return result;
        }

        // PUT: api/Booking/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateBookingCommand request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }
            await _bookingService.Update(id, request);
            return NoContent();
        }

        // DELETE: api/Booking/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _bookingService.Delete(id);
            return NoContent();
        }
    }
}
