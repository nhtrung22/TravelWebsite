using Microsoft.AspNetCore.Mvc;
using TravelWebsite.API.Controllers;
using TravelWebsite.Business.Common.Attributes;
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Booking/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Booking
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BookingDTO booking)
        {
            await _bookingService.Create(booking);
            return NoContent();
        }

        // PUT: api/Booking/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Booking/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
