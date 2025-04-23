using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wypozyczalnia1.Models;

namespace Wypozyczalnia1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IMapper _mapper;

        public ReservationController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateReservation([FromBody] ReservationViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reservation = _mapper.Map<Reservation>(viewModel);
            // Tu zapis do bazy danych...

            return Ok(reservation);
        }
    }
}
