using DFDS.Dto;
using DFDS.Services;
using Microsoft.AspNetCore.Mvc;

namespace DFDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : BaseController
    {
        private readonly IBookingService _bookingService;
        private readonly IPassengerService _passengerService;

        public PassengerController(IBookingService bookingService, IPassengerService passengerService)
        {
            _bookingService = bookingService;
            _passengerService = passengerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _passengerService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSingle([FromRoute] Guid id)
        {
            var result = await _passengerService.Get(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}/bookings")]
        public async Task<IActionResult> GetPassengerBookings([FromRoute] Guid id)
        {

            var result = await _bookingService.GetByPassenger(id);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePassenger([FromRoute] Guid id)
        {
            await _passengerService.Delete(id);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePassenger([FromRoute] Guid id, [FromBody] PassengerDto passenger)
        {

            await _passengerService.Update(id, passenger);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePassenger([FromBody] PassengerDto passenger)
        {

            await _passengerService.Create(passenger);
            return Ok();
        }
    }
}
