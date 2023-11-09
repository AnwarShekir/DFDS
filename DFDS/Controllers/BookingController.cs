using DFDS.Dto;
using DFDS.Services;
using Microsoft.AspNetCore.Mvc;

namespace DFDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : BaseController
    {
        private readonly IBookingService _bookingService;
        private readonly IPassengerService _passengerService;

        public BookingController(IBookingService bookingService, IPassengerService passengerService)
        {
            _bookingService = bookingService;
            _passengerService = passengerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
                var result =  await _bookingService.GetAll();
                return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSingle([FromRoute] Guid id)
        {
                var result = await _bookingService.Get(id);
                return Ok(result);
        }

        [HttpGet]
        [Route("{id}/passengers")]
        public async Task<IActionResult> GetBookingPassengers([FromRoute] Guid id)
        {

            var result = await _passengerService.GetByBooking(id);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBooking([FromRoute] Guid id)
        {
            await _bookingService.Delete(id);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBooking([FromRoute] Guid id, [FromBody] BookingDto booking)
        {

            await _bookingService.Update(id, booking);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] BookingDto booking)
        {

            await _bookingService.Create(booking);
            return Ok();
        }

    }
}
