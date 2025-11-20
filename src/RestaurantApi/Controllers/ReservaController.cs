using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;
using RestaurantAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly RestaurantContext _context;
        private readonly ReservaService _service;

        public ReservaController(RestaurantContext context, ReservaService service)
        {
            _context = context;
            _service = service;
        }

        //admin functions
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reserva reserva)
        {
            var result = await _service.CreateAsync(reserva);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            return ok ? Ok() : NotFound();
        }

        //view users
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var reservas = await _service.GetAllAsync();
            return Ok(reservas);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reserva = await _service.GetByIdAsync(id);
            return reserva == null ? NotFound() : Ok(reserva);
        }
    }
}
